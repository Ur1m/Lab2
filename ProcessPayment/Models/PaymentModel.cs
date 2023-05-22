namespace ProcessPayment.Models
{
    public class PaymentModel
    {
        public string cardNumber { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public string cvc { get; set; }
        public int value { get; set; }
    }
}
