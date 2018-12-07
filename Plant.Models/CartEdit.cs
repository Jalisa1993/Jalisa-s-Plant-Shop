﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Models
{
    public class CartEdit
    {
        public int CartId { get; set; }
        public Guid UserId { get; set; }
        public int PlantId { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual Plant.Data.Plant Plant { get; set; }
    }
}
