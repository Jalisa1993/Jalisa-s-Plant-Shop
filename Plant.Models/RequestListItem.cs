using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Models
{
    public class RequestListItem
    {
        [Required]
        public int RequestId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Content { get; set; }

    } 
}
