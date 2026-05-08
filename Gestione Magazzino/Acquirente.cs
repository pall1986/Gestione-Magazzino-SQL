using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestione_Magazzino
{
    public class Acquirente
    {
        public string P_Iva { get; set; }
        public string RagioneSociale { get; set; }
        public string Indirizzo { get; set; }

        // Invece di avere solo la stringa "CapComune", abbiamo l'oggetto Comune
        public Comune ComuneResidenza { get; set; }

        // Navigazione: Un acquirente ha molte fatture
        public List<Fattura> Fatture { get; set; } = new List<Fattura>();
    }
}
