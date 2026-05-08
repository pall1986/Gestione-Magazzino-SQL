using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestione_Magazzino
{
    public class GiacenzaMagazzino
    {
        public string NomeMagazzino { get; set; } // es. "Corsia A", "Magazzino Centrale"
        public Merce MerceStoccata { get; set; }
        public int QuantitaDisponibile { get; set; }
    }
}