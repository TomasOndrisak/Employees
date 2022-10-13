using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastruktura.Models
{
    public partial class Employees
    {   
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Adress { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public DateTime DateOfEntry { get; set; }
        [Required]
        public bool Archived { get; set; }
        [Required]
        [ForeignKey(nameof(Positions))]
        public int PositionId { get; set; }
        [ForeignKey(nameof(PositionId))]
        public Positions Positions {get; set;}

        
        
        
    }
}
