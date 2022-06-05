using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyClone.Models;

namespace UdemyClone.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desctription { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
