using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestione_Magazzino
{
    public class RigaFattura
    {
        // Riferimenti agli oggetti collegati
        public Fattura FatturaDiRiferimento { get; set; }
        public Merce Articolo { get; set; }

        // Dati specifici dell'associazione
        public int QuantitaVenduta { get; set; }
        public decimal PrezzoVendita { get; set; } // Il prezzo storicizzato
    }
}
