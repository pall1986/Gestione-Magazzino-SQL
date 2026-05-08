using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Gestione_Magazzino
    {
        public class DettaglioFattura
        {
            public int IdDettaglio { get; set; }
            public int IdFattura { get; set; }
            public Merce MerceAcquistata { get; set; }
            public int Quantita { get; set; }
            public decimal PrezzoApplicato { get; set; }
        }
    }
