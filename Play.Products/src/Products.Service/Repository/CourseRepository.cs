using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Play.Products.Service.Enteties;

namespace Play.Products.Service.Repository
{
	public class CourseRepository : ICourseRepository
	{

        private readonly IMongoCollection<Course> DbCollection;
        private readonly FilterDefinitionBuilder<Course> filterBuilder = Builders<Course>.Filter;

        public CourseRepository(IMongoDatabase database, string collectionName)
        {
            DbCollection = database.GetCollection<Course>(collectionName);
        }

        public async Task<IReadOnlyCollection<Course>> GetAllAsync()
        {
            return await DbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<Course> GetAsync(int id)
        {
            FilterDefinition<Course> filter = filterBuilder.Eq(entity => entity.CourseId, id);
            return await DbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            await DbCollection.InsertOneAsync(course);
        }

        public async Task UpdateAsync(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            FilterDefinition<Course> filter = filterBuilder.Eq(c=> c.CourseId, course.CategoryId);
            await DbCollection.ReplaceOneAsync(filter, course);
        }

        public async Task RemoveAsync(int id)
        {

            FilterDefinition<Course> filter = filterBuilder.Eq(entity => entity.CourseId, id);
            await DbCollection.DeleteOneAsync(filter);
            {

            }
        }


    
}

}