using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyClone.Models
{
    public class Review
    {
        [Key]
        public int  ReviewId { get; set; }
        public string Comment { get; set; }
        public string  UserId { get; set; }
        public Product product { get; set; }
        public int Id { get; set; }
    }
}
