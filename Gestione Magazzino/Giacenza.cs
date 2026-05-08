using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestione_Magazzino
{
    public class Giacenza
    {
        // Riferimenti agli oggetti collegati
        public Merce Articolo { get; set; }
        public Magazzino Scaffale { get; set; }

        // Dati specifici dell'associazione
        public int QuantitaInGiacenza { get; set; }
    }
}
