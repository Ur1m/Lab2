using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Play.Products.Service.Enteties;

namespace Play.Products.Service.Repository
{
	public class CategoryRepository : ICategoryRepository
	{

        private readonly IMongoCollection<Category> DbCollection;
        private readonly FilterDefinitionBuilder<Category> filterBuilder = Builders<Category>.Filter;

        public CategoryRepository(IMongoDatabase database, string collectionName)
        {
            DbCollection = database.GetCollection<Category>(collectionName);
        }

        public async Task<IReadOnlyCollection<Category>> GetAllAsync()
        {
            return await DbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            FilterDefinition<Category> filter = filterBuilder.Eq(entity => entity.CategoryId, id);
            return await DbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            await DbCollection.InsertOneAsync(category);
        }

        public async Task UpdateAsync(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            FilterDefinition<Category> filter = filterBuilder.Eq(categ => categ.CategoryId, category.CategoryId);
            await DbCollection.ReplaceOneAsync(filter, category);
        }

        public async Task RemoveAsyc(int id)
        {

            FilterDefinition<Category> filter = filterBuilder.Eq(entity => entity.CategoryId, id);
            await DbCollection.DeleteOneAsync(filter);
            {

            }
        }


    
}

}