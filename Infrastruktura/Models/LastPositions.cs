using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastruktura.Models
{
    public partial class LastPositions
    {
        
       public int LastPositionId {get; set;}
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime DateOfLeave { get; set; }
        
        [ForeignKey(nameof(PositionId))]
        public Positions Positions {get; set;}
    }
}
