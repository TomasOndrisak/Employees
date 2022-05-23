using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastruktura.Models
{
    public partial class PredoslePozicie
    {
        
       public int IDPredoslej {get; set;}
        public int ZamestnanecId { get; set; }
        public int PoziciaId { get; set; }
        public DateTime DatumNastupu { get; set; }
        public DateTime DatumUkoncenia { get; set; }
    }
}
