using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Data
{
    public enum PlantType
    {
        Annual,
        Evergreen,
        Perennials,
        Biennial,
    }

    public class Plant
    {
        [Key]
        public int PlantId { get; set; }
        [Required]
        public string PlantName { get; set; }
        [Required]
        public PlantType TypeOfPlant { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
    }
}
