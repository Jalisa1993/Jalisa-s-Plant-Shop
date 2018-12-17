using Plant.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Models
{
    public class CartEdit
    {
        public int CartId { get; set; }
        public int PlantId { get; set; }
        public virtual PlantItem Plant { get; set; }
        public int Quantity { get; set; }
    }
}
