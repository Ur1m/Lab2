using System;

namespace Event.ProductsContract
{
    public class CartEventDto
    {
        public string userId { get; set; }
        public int ProductId { get; set; }
    }
}
