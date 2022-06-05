using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyClone.Models;

namespace UdemyClone.DTO
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        public Product product { get; set; }
        public int Id { get; set; }
    }
}
