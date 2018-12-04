using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Models
{
    public enum PlantType
    {
        Annual,
        Evergreen,
        Perennials,
        Biennial,
    }

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

        public override string ToString() => Name;
        
    }
}
