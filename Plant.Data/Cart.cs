using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Data
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PlantId { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public virtual Plant Plants { get; set; }
    }
}
