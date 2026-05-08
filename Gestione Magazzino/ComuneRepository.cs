using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;

namespace Gestione_Magazzino
{
    public class ComuneRepository
    {
        private readonly string _stringaConnessione;

        public ComuneRepository(string stringaConnessione)
        {
            _stringaConnessione = stringaConnessione;
        }

        public async Task<List<Comune>> OttieniTuttiIComuniAsync()
        {
            var comuni = new List<Comune>();
            using (var conn = new MySqlConnection(_stringaConnessione))
            {
                await conn.OpenAsync();
                string query = "SELECT CAP, CITTA, PROVINCIA FROM COMUNE";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        comuni.Add(new Comune
                        {
                            CAP = reader.GetString("CAP"),
                            Citta = reader.GetString("CITTA"),
                            Provincia = reader.GetString("PROVINCIA")
                        });
                    }
                }
            }
            return comuni;
        }

        public async Task AggiungiComuneAsync(Comune comune)
        {
            using (var conn = new MySqlConnection(_stringaConnessione))
            {
                await conn.OpenAsync();
                string query = "INSERT INTO COMUNE (CAP, CITTA, PROVINCIA) VALUES (@cap, @citta, @prov)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cap", comune.CAP);
                    cmd.Parameters.AddWithValue("@citta", comune.Citta);
                    cmd.Parameters.AddWithValue("@prov", comune.Provincia);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}