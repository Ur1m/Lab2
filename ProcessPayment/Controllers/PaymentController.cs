﻿using Microsoft.AspNetCore.Http;
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
        private readonly IMakePayment _makePayment;
        public PaymentController(IMakePayment makePayment)
        {
            _makePayment = makePayment;
        }

        [HttpPost]
        public async Task<string> MakePayment(PaymentModel credentials)
        {
           return await _makePayment.PayAsync(credentials.cardNumber, credentials.month, credentials.year, credentials.cvc, credentials.value);
        }
    }
}
