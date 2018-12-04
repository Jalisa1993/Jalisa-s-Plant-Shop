using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Models
{
    public class RequestCreate
    {
        [Key]
        public int RequestId { get; set; }
        [Required]
        public int UserId { get; set; }

        public override int GetHashCode() => UserId;
    }
}
