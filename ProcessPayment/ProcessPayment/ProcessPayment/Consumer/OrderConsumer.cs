using MassTransit;
using System.Threading.Tasks;
using System;
using Event.ProductsContract;

namespace ProcessPayment.Consumer
{
    public class OrderConsumer : IConsumer<ProcessPaymentDto>
    {
        public Task Consume(ConsumeContext<ProcessPaymentDto> context)
        {
            var result = context.Message;

            throw new NotImplementedException();
        }
    }
}