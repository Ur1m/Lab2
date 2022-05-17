
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Play.Products.Service.Enteties;

namespace Play.Products.Service.Repository
{
    public interface ICourseRepository
    {
        
        Task CreateAsync(Course course);
        Task<IReadOnlyCollection<Course>> GetAllAsync();
        Task<Course> GetAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(Course course);
    }
}