using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyClone.Models
{
    public class Product
    {
        [Key]
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Desctription { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; }
        public Category Category { get; set; }
        public int  CategoryId { get; set; }
    }
}
