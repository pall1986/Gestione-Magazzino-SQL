using Gestione_Magazzino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestione_Magazzino
{
    public class Comune

    {
        public string CAP { get; set; }
        public string Citta { get; set; }
        public string Provincia { get; set; }

        // Navigazione: Un comune può avere molti acquirenti residenti
        public List<Acquirente> AcquirentiResidenti { get; set; } = new List<Acquirente>();
    }









}
