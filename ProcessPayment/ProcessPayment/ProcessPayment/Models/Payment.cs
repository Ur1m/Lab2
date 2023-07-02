using System;

namespace ProcessPayment.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string CVC { get; set; }
        public decimal Value { get; set; }
        public DateTime PaymentTime { get; set; }
    }
}