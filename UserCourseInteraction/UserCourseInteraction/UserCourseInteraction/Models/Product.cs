using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserCourseInteraction.Models
{
    public class Product
    {
        [Key]
        public int productId { get; set; }
        public string name { get; set; }
        public double price { get; set; }

    }
}
