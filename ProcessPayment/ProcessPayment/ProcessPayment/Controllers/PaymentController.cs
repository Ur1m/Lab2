using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessPayment.Models;
using ProcessPayment.Services;
using System.Threading.Tasks;

namespace ProcessPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _makePayment;
        public PaymentController(IPaymentService makePayment)
        {
            _makePayment = makePayment;
        }

        [HttpPost]
        public async Task<string> MakePayment(PaymentInfo credentials)
        {
            return await _makePayment.PayAsync(credentials.CardNumber, credentials.Month, credentials.Year, credentials.Cvc, credentials.Value);
        }
    }
}
