using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Play.Products.Service.Enteties;
namespace Play.Products.Service.Repository
{
    public interface IAttributeValueRepository
    {
          Task CreateAsync(AttributeValue attrvalue);
        Task<IReadOnlyCollection<AttributeValue>> GetAllAsync();
        Task<AttributeValue> GetAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(AttributeValue attrvalue);
    }
}