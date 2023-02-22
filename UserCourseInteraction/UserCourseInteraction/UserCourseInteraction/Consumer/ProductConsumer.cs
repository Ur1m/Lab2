using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using MassTransit;
using UserCourseInteraction.Repositories;
using UserCourseInteraction.Models;
using Event.ProductsContract;

namespace UserCourseInteraction.Consumer
{
    public class ProductConsumer : IConsumer<CartEventDto>
    {
        private readonly IRepository<ShoppingCart> _repository;

        public ProductConsumer(IRepository<ShoppingCart> repository)
        {
            _repository = repository;
        }


        public async Task Consume(ConsumeContext<CartEventDto> context)
        {
            try
            {
                var obj = new ShoppingCart()
                {
                    ProductId = context.Message.ProductId,
                    userId = context.Message.userId
                };
                _repository.Add(obj);
            }
            catch (Exception)
            {

            }
        }
    }
}