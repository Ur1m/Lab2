using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Play.Products.Service.Enteties;

namespace Play.Products.Service.Repository
{
    public interface IItemsRepository
    {
        Task CreateAsync(Items entity);
        Task<IReadOnlyCollection<Items>> GetAllAsync();
        Task<Items> GetAsync(Guid id);
        Task RemoveAsyc(Guid id);
        Task UpdateAsync(Items entity);
    }
}