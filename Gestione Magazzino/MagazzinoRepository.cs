
using System.Text;


using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;

namespace Gestione_Magazzino
{
    public class MagazzinoRepository
    {
        private readonly string _connectionString;

        public MagazzinoRepository(string connectionString) => _connectionString = connectionString;

        // Ottiene quanta merce c'è in totale in un magazzino
        public async Task<int> OttieniDisponibilitaMerceAsync(int idMerce)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                // Usiamo QUANTITA_GIACENZA e custodita_in
                string query = "SELECT SUM(QUANTITA_GIACENZA) FROM custodita_in WHERE ID_MERCE = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32) { Value = idMerce });
                    var res = await cmd.ExecuteScalarAsync();
                    return res != DBNull.Value && res != null ? Convert.ToInt32(res) : 0;
                }
            }
        }

        // Metodo per stoccare la merce
        public async Task DisponiMerceAsync(int idScaffale, int idMerce, int quantita)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                // Usiamo ID_SCAFFALE e QUANTITA_GIACENZA
                string query = @"INSERT INTO custodita_in (ID_SCAFFALE, ID_MERCE, QUANTITA_GIACENZA) 
                         VALUES (@idScaf, @idMerce, @qta) 
                         ON DUPLICATE KEY UPDATE QUANTITA_GIACENZA = QUANTITA_GIACENZA + @qta";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@idScaf", MySqlDbType.Int32) { Value = idScaffale });
                    cmd.Parameters.Add(new MySqlParameter("@idMerce", MySqlDbType.Int32) { Value = idMerce });
                    cmd.Parameters.Add(new MySqlParameter("@qta", MySqlDbType.Int32) { Value = quantita });
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
