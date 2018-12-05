﻿using Plant.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Models
{
    public class PlantListItem
    { 
        [Required]
        public string PlantName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public PlantType TypeOfPlant { get; set; }
    }

}
