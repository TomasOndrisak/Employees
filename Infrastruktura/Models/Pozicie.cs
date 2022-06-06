using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastruktura.Models
{
    public partial class Pozicie
    {
        [Required]
      
        public int PoziciaId { get; set; }
        [Required]
        public string NazovPozicie { get; set; }
        
      
        

    }
}
