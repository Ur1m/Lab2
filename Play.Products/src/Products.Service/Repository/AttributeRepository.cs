using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Play.Products.Service.Enteties;

namespace Play.Products.Service.Repository
{
    public class AttributeRepository:IAttributeRepository
    {
         private readonly IMongoCollection<Play.Products.Service.Enteties.Attribute> DbCollection;
        private readonly FilterDefinitionBuilder<Play.Products.Service.Enteties.Attribute> filterBuilder = Builders<Play.Products.Service.Enteties.Attribute>.Filter;

        public AttributeRepository(IMongoDatabase database, string collectionName)
        {
            DbCollection = database.GetCollection<Play.Products.Service.Enteties.Attribute>(collectionName);
        }

        public async Task<IReadOnlyCollection<Play.Products.Service.Enteties.Attribute>> GetAllAsync()
        {
            return await DbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<Play.Products.Service.Enteties.Attribute> GetAsync(Guid id)
        {
            FilterDefinition<Play.Products.Service.Enteties.Attribute> filter = filterBuilder.Eq(entity => entity.AttributeId, id);
            return await DbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Play.Products.Service.Enteties.Attribute entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await DbCollection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(Play.Products.Service.Enteties.Attribute entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            FilterDefinition<Play.Products.Service.Enteties.Attribute> filter = filterBuilder.Eq(existingEntity => existingEntity.AttributeId, entity.AttributeId);
            await DbCollection.ReplaceOneAsync(filter, entity);
        }

        public async Task RemoveAsyc(Guid id)
        {

            FilterDefinition<Play.Products.Service.Enteties.Attribute> filter = filterBuilder.Eq(entity => entity.AttributeId, id);
            await DbCollection.DeleteOneAsync(filter);
            {

            }
        }


    }
}