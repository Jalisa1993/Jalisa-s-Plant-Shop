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
        [Key]
        [Display(Name ="Plant Id")]
        public int PlantId { get; set; }
        [Required]
        [Display(Name ="Plant Name")]
        public string PlantName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public PlantType TypeOfPlant { get; set; }
        [Required]
        public decimal Price { get; set; }

        public override string ToString() => PlantName;
    }

}
