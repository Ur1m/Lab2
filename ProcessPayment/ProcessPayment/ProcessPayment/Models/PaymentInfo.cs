namespace ProcessPayment.Models
{
    public class PaymentInfo
    {
        public string CardNumber { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Cvc { get; set; }
        public int Value { get; set; }
    }
}
