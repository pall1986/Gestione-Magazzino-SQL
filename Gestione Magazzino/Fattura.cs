using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestione_Magazzino
{
    public class Fattura
    {
        public int IdFattura { get; set; }
        public string NumeroFattura { get; set; }
        public DateTime DataEmissione { get; set; }

        // Riferimento all'oggetto Acquirente (FK)
        public Acquirente Intestatario { get; set; }

        // Navigazione: Una fattura è composta da molte righe
        public List<RigaFattura> Righe { get; set; } = new List<RigaFattura>();

        // Metodo di utilità per il calcolo del totale
        public decimal CalcolaTotale()
        {
            decimal totale = 0;
            foreach (var riga in Righe)
            {
                totale += riga.QuantitaVenduta * riga.PrezzoVendita;
            }
            return totale;
        }
    }
    // Mappa la tabella RIGHE_FATTURA


    // Mappa la tabella CUSTODITA_IN
}
