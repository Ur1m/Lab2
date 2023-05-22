using Stripe;
using System.Threading.Tasks;

namespace ProcessPayment.Services
{
    public class MakePayment : IMakePayment
    {
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
                    return "succesfully";
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
