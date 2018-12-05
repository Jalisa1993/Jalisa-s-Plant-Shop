﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Models
{
   public class CartCreate
    {
        [Required]
        public int CartId { get; set; }
        [Required]
        public int PlantId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
    }
}
