using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Models
{
    class CartCreate
    {
        [Key]
        public int CartId { get; set; }
        [Required]
        public int PlantId { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }


        public override int GetHashCode() => PlantId;
    }
}
