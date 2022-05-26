using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastruktura.Models
{
    public partial class Zamestnanci
    {   
        [Required]
        public int ZamestnanecId { get; set; }
        [Required]
        public string Meno { get; set; }
        [Required]
        public string Priezvisko { get; set; }
        public string Adresa { get; set; }
        [Required]
        public DateTime DatumNarodenia { get; set; }
        [Required]
        public DateTime DatumNastupu { get; set; }
        [Required]
        public bool Archivovany { get; set; }
        //FK pozicie
        [Required]
        public int IdPozicie { get; set; }

        // public Pozicie Pozicie {get; set;}
        
        
    }
}
