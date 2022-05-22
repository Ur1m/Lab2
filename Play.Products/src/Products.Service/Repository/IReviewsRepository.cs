using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Play.Products.Service.Enteties;
namespace Play.Products.Service.Repository
{
    public interface IReviewsRepository
    {
          Task AddAsync(Reviews Reviews);
        Task<IReadOnlyCollection<Reviews>> GetAllLikesAsync(int Id);
        Task<IReadOnlyCollection<Reviews>> GetAllRatesAsync(int Id);
         Task<IReadOnlyCollection<Reviews>> GetAllDislikesAsync(int Id);
         Task<IReadOnlyCollection<Reviews>> GetAllCommentsAsync(int Id);
         Task<Reviews> GetById(int id);
                Task RemoveAsyc(int id);
        Task UpdateAsync(Reviews Reviews);
    }
}