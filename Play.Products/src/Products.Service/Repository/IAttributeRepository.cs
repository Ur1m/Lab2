using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Play.Products.Service.Enteties;
namespace Play.Products.Service.Repository
{
    public interface IAttributeRepository
    {
        
        Task CreateAsync(Play.Products.Service.Enteties.Attribute entity);
        Task<IReadOnlyCollection<Play.Products.Service.Enteties.Attribute>> GetAllAsync();
        Task<Play.Products.Service.Enteties.Attribute> GetAsync(Guid id);
        Task RemoveAsyc(Guid id);
        Task UpdateAsync(Play.Products.Service.Enteties.Attribute entity);
        
       
    }
}