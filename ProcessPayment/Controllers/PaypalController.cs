using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;

namespace ProcessPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaypalController : ControllerBase
    {
        private readonly PayPalHttpClient _client;

        public PaypalController(PayPalHttpClient client)
        {
            _client = client;
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreatePayment()
        {
            var request = new OrdersCreateRequest();

            request.Prefer("return=representation");
            request.RequestBody(BuildRequestBody());

            var response = await _client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                var order = response.Result<PayPalCheckoutSdk.Orders.Order>();

                var url = order.Links.FirstOrDefault(x => x.Rel.Equals("approve", StringComparison.OrdinalIgnoreCase)).Href;

                if (url != null)
                {
                    HttpContext.Response.Redirect(url);

                    var captureId = order.PurchaseUnits[0].Payments.Captures[0].Id;
                    
                    return url;
                }
            }
            else
            {
                return BadRequest(response);
            }
         
            return BadRequest(response);
        }

        private OrderRequest BuildRequestBody()
        {
            var orderRequest = new OrderRequest()
            {
                CheckoutPaymentIntent = "CAPTURE",
                PurchaseUnits = new List<PurchaseUnitRequest>()
                {
                new PurchaseUnitRequest()
                {
                AmountWithBreakdown = new AmountWithBreakdown()
                {
                    CurrencyCode = "USD",
                    Value = "100.00",
                    AmountBreakdown = new AmountBreakdown()
                    {
                        ItemTotal = new Money()
                        {
                            CurrencyCode = "USD",
                            Value = "100.00"
                        }
                    }
                },
                Payee = new Payee()
                {
                    ClientId = "AbCSHuVSK0PTGNAUqJtWXM8gbZtNMA8P1Ro2NqnFFqgXdplCpREF9-sNuNXTTW_YAuPtxHeGutN28eHq",
                Email = "sb-cyysg25568070@business.example.com"
                },
                ShippingDetail = new ShippingDetail()
                {
                    Name = new Name()
                    {
                        FullName = "John Doe"
                    },
                    AddressPortable = new AddressPortable()
                    {
                        AddressLine1 = "123 Main St",
                        AddressLine2 = "Apt 4B",
                        AdminArea2 = "Anytown",
                        AdminArea1 = "CA",
                        PostalCode = "12345",
                        CountryCode = "US"
                    }
                }
            }
        },
                ApplicationContext = new ApplicationContext()
                {
                    BrandName = "Your Brand Name",
                    LandingPage = "BILLING",
                    ShippingPreference = "SET_PROVIDED_ADDRESS"
                }
            };

            return orderRequest;
        }
    }
}
