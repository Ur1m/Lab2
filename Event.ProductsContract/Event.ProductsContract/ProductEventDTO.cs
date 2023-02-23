using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.ProductsContract
{
    public class ProductEventDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desctription { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public int CategoryId { get; set; }
    }
}
