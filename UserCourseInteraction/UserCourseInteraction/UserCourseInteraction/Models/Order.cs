using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserCourseInteraction.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string userId { get; set; }
        public double totalPrice { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
