using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestione_Magazzino
{
    public class Merce
    {
        public int IdMerce { get; set; }
        public string Descrizione { get; set; }
        public decimal PrezzoUnitario { get; set; }

        // Navigazione verso le relazioni
        public List<RigaFattura> RigheVendita { get; set; } = new List<RigaFattura>();
        public List<Giacenza> Giacenze { get; set; } = new List<Giacenza>();
    }
}
