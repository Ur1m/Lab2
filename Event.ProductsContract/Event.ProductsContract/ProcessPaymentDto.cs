using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.ProductsContract
{
    public class ProcessPaymentDto
    {
        public string CardNumber { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Cvc { get; set; }
        public int Value { get; set; }
    }
}
