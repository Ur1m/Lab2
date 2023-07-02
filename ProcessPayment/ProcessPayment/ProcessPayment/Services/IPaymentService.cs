using System.Threading.Tasks;

namespace ProcessPayment.Services
{
    public interface IPaymentService
    {
        Task<dynamic> PayAsync(string cardNumber, string month, string year, string cvc, int value);
    }
}
