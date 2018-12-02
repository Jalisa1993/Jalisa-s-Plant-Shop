using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Models
{
   public class CartListItem
    {
        public int CartId { get; set; }
        public int PlantId { get; set; }
        public decimal TotalPrice { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
