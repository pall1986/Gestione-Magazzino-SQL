using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;

namespace Gestione_Magazzino
{
    public class FatturaRepository
    {
        private readonly string _connectionString;

        public FatturaRepository(string connectionString) => _connectionString = connectionString;

        // Inserimento Fattura con pattern transazionale e Prepared Statements
        public async Task EmettiFatturaAsync(Fattura fattura, List<DettaglioFattura> dettagli)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                // Avviamo una transazione per salvaguardare l'integrità dei dati
                using (var transaction = await conn.BeginTransactionAsync())
                {
                    try
                    {
                        // 1. Inserimento testata Fattura
                        string queryFattura = "INSERT INTO FATTURA (NUMERO_FATTURA, DATA_EMISSIONE, P_IVA_ACQUIRENTE) VALUES (@num, @data, @piva); SELECT LAST_INSERT_ID();";
                        int idFatturaGenerato;

                        using (var cmd = new MySqlCommand(queryFattura, conn, transaction))
                        {
                            cmd.Parameters.Add(new MySqlParameter("@num", MySqlDbType.VarChar) { Value = fattura.NumeroFattura });
                            cmd.Parameters.Add(new MySqlParameter("@data", MySqlDbType.Date) { Value = fattura.DataEmissione });
                            cmd.Parameters.Add(new MySqlParameter("@piva", MySqlDbType.VarChar) { Value = fattura.Intestatario.P_Iva });
                            await cmd.PrepareAsync();
                            idFatturaGenerato = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                        }

                        // 2. Inserimento dettagli righe e scarico automatico magazzino
                        // 2. Inserimento dettagli righe (Tabella: righe_fattura)
                        foreach (var det in dettagli)
                        {
                            // Verifica su phpMyAdmin se i nomi ID_FATTURA, ID_MERCE, QUANTITA, PREZZO_APPLICATO sono corretti
                            // Allineamento con i nomi reali del tuo DB (image_b29472.png)
                            string queryDettaglio = @"INSERT INTO righe_fattura 
                          (ID_FATTURA, ID_MERCE, QUANTITA_VENDUTA, PREZZO_VENDITA) 
                          VALUES (@idFat, @idMerce, @qta, @prezzo)";

                            using (var cmdDet = new MySqlCommand(queryDettaglio, conn, transaction))
                            {
                                cmdDet.Parameters.Add(new MySqlParameter("@idFat", MySqlDbType.Int32) { Value = idFatturaGenerato });
                                cmdDet.Parameters.Add(new MySqlParameter("@idMerce", MySqlDbType.Int32) { Value = det.MerceAcquistata.IdMerce });
                                cmdDet.Parameters.Add(new MySqlParameter("@qta", MySqlDbType.Int32) { Value = det.Quantita });
                                cmdDet.Parameters.Add(new MySqlParameter("@prezzo", MySqlDbType.Decimal) { Value = det.PrezzoApplicato });

                                await cmdDet.ExecuteNonQueryAsync();
                            }

                            // 3. Scarico automatico magazzino (Tabella: custodita_in)
                            // Usiamo QUANTITA_GIACENZA come visto nello screenshot precedente
                            string queryScarico = "UPDATE custodita_in SET QUANTITA_GIACENZA = QUANTITA_GIACENZA - @qta WHERE ID_MERCE = @idMerce AND ID_SCAFFALE = @idScaf LIMIT 1";
                            using (var cmdScarico = new MySqlCommand(queryScarico, conn, transaction))
                            {
                                cmdScarico.Parameters.Add(new MySqlParameter("@qta", MySqlDbType.Int32) { Value = det.Quantita });
                                cmdScarico.Parameters.Add(new MySqlParameter("@idMerce", MySqlDbType.Int32) { Value = det.MerceAcquistata.IdMerce });
                                // Nota: qui servirebbe sapere da quale scaffale scaricare. 
                                // Per ora puoi puntare a uno specifico o rimuovere il filtro ID_SCAFFALE se vuoi scaricare dal primo disponibile.
                                cmdScarico.Parameters.Add(new MySqlParameter("@idScaf", MySqlDbType.Int32) { Value = 1 });
                                await cmdScarico.ExecuteNonQueryAsync();
                            }
                        }

                        // Se tutto è andato a buon fine confermiamo le modifiche nel DB
                        await transaction.CommitAsync();
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync(); // Annulla tutto in caso di errore
                        throw;
                    }
                }
            }
        }

        // Carica le fatture filtrate per acquirente
        public async Task<List<Fattura>> OttieniFatturePerAcquirenteAsync(string pIva)
        {
            var lista = new List<Fattura>();
            using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT ID_FATTURA, NUMERO_FATTURA, DATA_EMISSIONE FROM FATTURA WHERE P_IVA_ACQUIRENTE = @piva";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@piva", MySqlDbType.VarChar) { Value = pIva });
                    await cmd.PrepareAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new Fattura
                            {
                                IdFattura = reader.GetInt32("ID_FATTURA"),
                                NumeroFattura = reader.GetString("NUMERO_FATTURA"),
                                DataEmissione = reader.GetDateTime("DATA_EMISSIONE")
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}
