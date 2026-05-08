using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;

namespace Gestione_Magazzino
{
    public class AcquirenteRepository
    {
        private readonly string _connectionString;

        public AcquirenteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Acquirente>> OttieniTuttiGliAcquirentiAsync()
        {
            var lista = new List<Acquirente>();
            using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                // Utilizziamo una JOIN per recuperare anche i dati del comune in un'unica chiamata
                string query = @"SELECT A.P_IVA, A.RAGIONE_SOCIALE, A.INDIRIZZO, 
                                        C.CAP, C.CITTA, C.PROVINCIA 
                                 FROM ACQUIRENTE A 
                                 INNER JOIN COMUNE C ON A.CAP_COMUNE = C.CAP";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    await cmd.PrepareAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new Acquirente
                            {
                                P_Iva = reader.GetString("P_IVA"),
                                RagioneSociale = reader.GetString("RAGIONE_SOCIALE"),
                                Indirizzo = reader.IsDBNull(2) ? "" : reader.GetString("INDIRIZZO"),
                                ComuneResidenza = new Comune
                                {
                                    CAP = reader.GetString("CAP"),
                                    Citta = reader.GetString("CITTA"),
                                    Provincia = reader.GetString("PROVINCIA")
                                }
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public async Task AggiungiAcquirenteAsync(Acquirente acq)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                string query = "INSERT INTO ACQUIRENTE (P_IVA, RAGIONE_SOCIALE, INDIRIZZO, CAP_COMUNE) VALUES (@piva, @rag, @ind, @cap)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@piva", MySqlDbType.VarChar) { Value = acq.P_Iva });
                    cmd.Parameters.Add(new MySqlParameter("@rag", MySqlDbType.VarChar) { Value = acq.RagioneSociale });
                    cmd.Parameters.Add(new MySqlParameter("@ind", MySqlDbType.VarChar) { Value = acq.Indirizzo });
                    cmd.Parameters.Add(new MySqlParameter("@cap", MySqlDbType.VarChar) { Value = acq.ComuneResidenza.CAP });

                    await cmd.PrepareAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}