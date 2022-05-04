using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Play.Products.Service.Enteties;

namespace Play.Products.Service.Repository
{
    public class ItemsRepository
    {
        private const string collectionName = "items";
        private readonly IMongoCollection<Items> DbCollection;
        private readonly FilterDefinitionBuilder<Items> filterBuilder = Builders<Items>.Filter;
        
        public ItemsRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("Products");
            DbCollection = database.GetCollection<Items>(collectionName); 
        }

        public async Task<IReadOnlyCollection<Items>> GetAllAsync()
        {
            return await DbCollection.Find(filterBuilder.Empty).ToListAsync(); 
        }

        public async Task<Items> GetAsync(Guid id)
        {
            FilterDefinition<Items> filter = filterBuilder.Eq(entity => entity.Id, id);
            return await DbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Items entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await DbCollection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(Items entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            FilterDefinition<Items> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
            await DbCollection.ReplaceOneAsync(filter, entity);
        }

        public async Task RemoveAsyc(Guid id)
        {
             if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            FilterDefinition<Items> filter = filterBuilder.Eq(entity => entity.Id, id);
            await DbCollection.DeleteOneAsync(filter);
            {

            }
        }







    }
}