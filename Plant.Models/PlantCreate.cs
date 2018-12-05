using Plant.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Models
{
    public class PlantCreate
    {
        [Key]
        public int PlantId { get; set; }
        [Required]
        public PlantType TypeOfPlant { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
    }
}
