using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Play.Products.Service.Enteties;

namespace Play.Products.Service.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        Task CreateAsync(T entity);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task RemoveAsyc(Guid id);
        Task UpdateAsync(T entity);
    }
}