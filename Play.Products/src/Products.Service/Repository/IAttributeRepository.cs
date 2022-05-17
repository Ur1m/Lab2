using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Play.Products.Service.Enteties;
namespace Play.Products.Service.Repository
{
    public interface IAttributeRepository
    {
         Task CreateAsync(Play.Products.Service.Enteties.Attribute attr);
        Task<IReadOnlyCollection<Play.Products.Service.Enteties.Attribute>> GetAllAsync();
        Task<Play.Products.Service.Enteties.Attribute> GetAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(Play.Products.Service.Enteties.Attribute attr);
         
    }
}