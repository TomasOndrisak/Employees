using System.ComponentModel.DataAnnotations;

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
