using Plant.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Models
{
   public class CartCreate
    {
        [Required]
        public int PlantId { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public virtual PlantItem Plant { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
