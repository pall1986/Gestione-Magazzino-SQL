using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;

namespace Gestione_Magazzino
{
    public class MerceRepository
    {
        private readonly string _stringaConnessione;

        public MerceRepository(string stringaConnessione)
        {
            _stringaConnessione = stringaConnessione;
        }

        public async Task<List<Merce>> OttieniTutteLeMerciAsync()
        {
            var catalogo = new List<Merce>();
            using (var conn = new MySqlConnection(_stringaConnessione))
            {
                await conn.OpenAsync();
                string query = "SELECT ID_MERCE, DESCRIZIONE, PREZZO_UNITARIO FROM MERCE";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    // Anche se non ci sono parametri, prepare pre-compila la query sul server
                    await cmd.PrepareAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            catalogo.Add(new Merce
                            {
                                IdMerce = reader.GetInt32("ID_MERCE"),
                                Descrizione = reader.GetString("DESCRIZIONE"),
                                PrezzoUnitario = reader.GetDecimal("PREZZO_UNITARIO")
                            });
                        }
                    }
                }
            }
            return catalogo;
        }

        public async Task AggiungiMerceAsync(Merce nuovaMerce)
        {
            using (var conn = new MySqlConnection(_stringaConnessione))
            {
                await conn.OpenAsync();
                string query = "INSERT INTO MERCE (DESCRIZIONE, PREZZO_UNITARIO) VALUES (@desc, @prezzo)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    // Definiamo esplicitamente i tipi per il Prepared Statement
                    cmd.Parameters.Add(new MySqlParameter("@desc", MySqlDbType.VarChar) { Value = nuovaMerce.Descrizione });
                    cmd.Parameters.Add(new MySqlParameter("@prezzo", MySqlDbType.Decimal) { Value = nuovaMerce.PrezzoUnitario });

                    // Inviamo il comando di "Prepare" al server MySQL
                    await cmd.PrepareAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task AggiornaMerceAsync(Merce merceDaModificare)
        {
            using (var conn = new MySqlConnection(_stringaConnessione))
            {
                await conn.OpenAsync();
                string query = "UPDATE MERCE SET DESCRIZIONE = @desc, PREZZO_UNITARIO = @prezzo WHERE ID_MERCE = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@desc", MySqlDbType.VarChar) { Value = merceDaModificare.Descrizione });
                    cmd.Parameters.Add(new MySqlParameter("@prezzo", MySqlDbType.Decimal) { Value = merceDaModificare.PrezzoUnitario });
                    cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32) { Value = merceDaModificare.IdMerce });

                    await cmd.PrepareAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminaMerceAsync(int idMerce)
        {
            using (var conn = new MySqlConnection(_stringaConnessione))
            {
                await conn.OpenAsync();
                string query = "DELETE FROM MERCE WHERE ID_MERCE = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32) { Value = idMerce });

                    await cmd.PrepareAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}