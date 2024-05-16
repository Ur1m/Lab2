using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserCourseInteraction.Models;

namespace UserCourseInteraction.Repositories
{
    public interface IRepository<T> where T: class
    {
        public void Add(T entity);
        public List<T> GetAll();
        public void AddRange(List<T> enteties);
        public void Update(T entity);
        public void Remove(T entiry);
    }
}
