using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastruktura.Models
{
    public partial class Positions
    {
        [Required]
      
        public int PositionId { get; set; }
        
        [Required]
        public string PositionName { get; set; }
        
      
        

    }
}
