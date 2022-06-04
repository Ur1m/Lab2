using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Play.Products.Service.Enteties;
namespace Play.Products.Service.Repository
{
    public interface IProductAttributeRepository
    {
         Task CreateAsync(ProductAttribute entity);
        Task<IReadOnlyCollection<ProductAttribute>> GetAllAsyncByProductId();
        
        Task RemoveAsyc(Guid ProductId,Guid AttributevalId);
       
         
    }
}