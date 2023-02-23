using Event.ProductsContract;
using MassTransit;
using System.Threading.Tasks;
using System;
using UserCourseInteraction.Models;
using UserCourseInteraction.Repositories;

namespace UserCourseInteraction.Consumer
{
    public class ProductPropertiesConsumer : IConsumer<ProductEventDTO>
    {
        private readonly IRepository<ProductDto> _repository;

        public ProductPropertiesConsumer(IRepository<ProductDto> repository)
        {
            _repository = repository;
        }


        public async Task Consume(ConsumeContext<ProductEventDTO> context)
        {
            try
            {
                var obj = new ProductDto()
                {
                   Id = context.Message.Id,
                   Name = context.Message.Name,
                   Desctription= context.Message.Desctription,
                   Image= context.Message.Image,
                   Price = context.Message.Price,
                   CreateDate= context.Message.CreateDate,
                   CategoryId = context.Message.CategoryId,
                };
                _repository.Add(obj);
            }
            catch (Exception)
            {

            }
        }
    }
}