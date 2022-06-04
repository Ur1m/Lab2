using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Play.Products.Service.Enteties;
namespace Play.Products.Service.Repository
{
    public class AttributeValueRepository:IAttributeValueRepository
    {
         private readonly IMongoCollection<AttributeValue> DbCollection;
        private readonly FilterDefinitionBuilder<AttributeValue> filterBuilder = Builders<AttributeValue>.Filter;

        public AttributeValueRepository(IMongoDatabase database, string collectionName)
        {
            DbCollection = database.GetCollection<AttributeValue>(collectionName);
        }

        public async Task<IReadOnlyCollection<AttributeValue>> GetAllAttrValuesAsync(Guid Id)
        {
            FilterDefinition<AttributeValue> filter = filterBuilder.Eq(entity => entity.AttributeId, Id);
            return await DbCollection.Find(filter).ToListAsync();
        }

        public async Task<AttributeValue> GetAttrValueAsync(Guid id)
        {
            FilterDefinition<AttributeValue> filter = filterBuilder.Eq(entity => entity.AttributeValueId, id);
            return await DbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(AttributeValue entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await DbCollection.InsertOneAsync(entity);
        }

        public async Task UpdateAttrValueAsync(AttributeValue entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            FilterDefinition<AttributeValue> filter = filterBuilder.Eq(existingEntity => existingEntity.AttributeValueId, entity.AttributeValueId);
            await DbCollection.ReplaceOneAsync(filter, entity);
        }

        public async Task RemoveAttrValueAsyc(Guid id)
        {

            FilterDefinition<AttributeValue> filter = filterBuilder.Eq(entity => entity.AttributeValueId, id);
            await DbCollection.DeleteOneAsync(filter);
            {

            }
        }


    }
}