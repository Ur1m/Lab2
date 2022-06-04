using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Play.Products.Service.Enteties;
namespace Play.Products.Service.Repository
{
    public interface IAttributeValueRepository
    {
          Task<IReadOnlyCollection<AttributeValue>> GetAllAttrValuesAsync(Guid Id);
        Task<AttributeValue> GetAttrValueAsync(Guid id);
       
        Task CreateAsync(AttributeValue entity);
        Task RemoveAttrValueAsyc(Guid id);
        Task UpdateAttrValueAsync(AttributeValue entity);
    }
}