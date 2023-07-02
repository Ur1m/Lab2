using Newtonsoft.Json.Linq;
using ProcessPayment.Models;
using System.Threading.Tasks;
using System;
using ProcessPayment.Repositories;
using Stripe;

namespace ProcessPayment.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PaymentRepository _paymentRepository;

        public PaymentService(PaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<dynamic> PayAsync(string cardNumber, string month, string year, string cvc, int value)
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51N93hdIyYXMuwulxAyhjXshW5zBL0WSl34ynk6XniOXAz0BcyvlWVkp1NZagRBKSChCTYh3reFWIPnlDB2zwFev400y8Ig5OFV";
                var optionstoken = new TokenCreateOptions
                {
                    Card = new Stripe.TokenCardOptions
                    {

                        Number = cardNumber,
                        ExpMonth = month,
                        ExpYear = year,
                        Cvc = cvc
                    }
                };

                var serviceToken = new TokenService();
                Token stripeToken = await serviceToken.CreateAsync(optionstoken);

                var options = new ChargeCreateOptions
                {
                    Amount = value,
                    Currency = "usd",
                    Description = "Test",
                    Source = stripeToken.Id
                };

                var service = new ChargeService();
                Charge charge = await service.CreateAsync(options);

                if (charge.Paid)
                {
                    var payment = new Payment
                    {
                        CardNumber = cardNumber,
                        Month = month,
                        Year = year,
                        CVC = cvc,
                        Value = value
                    };

                    await _paymentRepository.InsertPayment(payment);

                    return "successfully";
                }
                else
                {
                    return "failed";
                }

            }
            catch (System.Exception e)
            {

                throw;
            }
        }
    }
}
