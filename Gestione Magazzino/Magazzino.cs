using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestione_Magazzino
{
    public class Magazzino
    {
        public string IdScaffale { get; set; }
        public string Reparto { get; set; }
        public int Corsia { get; set; }

        // Navigazione: Uno scaffale contiene diverse giacenze di merci
        public List<Giacenza> MerciCustodite { get; set; } = new List<Giacenza>();
    }
}
