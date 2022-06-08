using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserCourseInteraction.Database;

namespace UserCourseInteraction.Repositories
{
    public class Repository<T> : IRepository<T> where T:class
    {
        public ApplicationDbContext _dbContext;
        DbSet<T> entities;
        public Repository(ApplicationDbContext context)
        {
            _dbContext = context;
            entities = _dbContext.Set<T>();

        }
        public void Add(T entity)
        {

            try
            {
                entities.Add(entity);
                _dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public void AddRange(List<T> enteties)
        {
            try
            {
                enteties.AddRange(enteties);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> GetAll()
        {
           return entities.ToList();
        }

      

        public void Remove(T entiry)
        {
            entities.Remove(entiry);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            entities.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
