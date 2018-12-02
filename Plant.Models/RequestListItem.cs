using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Models
{
   public class RequestListItem
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
