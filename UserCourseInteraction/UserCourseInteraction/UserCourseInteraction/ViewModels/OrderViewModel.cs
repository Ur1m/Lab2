using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserCourseInteraction.Models;

namespace UserCourseInteraction.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string userId { get; set; }
        public double totalPrice { get; set; }
        public DateTime CreatedOn { get; set; }
        public  List<Product> products { get; set; }
    }
}
