using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



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
