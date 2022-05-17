using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Play.Products.Service.Enteties;


namespace Play.Products.Service.Repository
{
    public interface ICategoryRepository
    {
        Task CreateAsync(Category category);
        Task<IReadOnlyCollection<Category>> GetAllAsync();
        Task<Category> GetAsync(int id);
        Task RemoveAsyc(int id);
        Task UpdateAsync(Category category);
    }
}
