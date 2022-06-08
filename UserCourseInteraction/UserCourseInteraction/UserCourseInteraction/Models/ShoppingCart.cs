using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserCourseInteraction.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public string userId { get; set; }
        public int ProductId { get; set; }

    }
}
