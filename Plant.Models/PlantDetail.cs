using Plant.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Models
{
    public class PlantDetail
    {

        public int PlantId { get; set; }
        public PlantType TypeOfPlant { get; set; }
        public string PlantName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
