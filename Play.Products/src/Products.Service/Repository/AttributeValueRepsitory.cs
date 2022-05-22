using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Play.Products.Service.Enteties;

namespace Play.Products.Service.Repository
{
	public class AttributeValueRepository : IAttributeValueRepository
	{

        private readonly IMongoCollection<AttributeValue> DbCollection;
        private readonly FilterDefinitionBuilder<AttributeValue> filterBuilder = Builders<AttributeValue>.Filter;

        public AttributeValueRepository(IMongoDatabase database, string collectionName)
        {
            DbCollection = database.GetCollection<AttributeValue>(collectionName);
        }

        public async Task<IReadOnlyCollection<AttributeValue>> GetAllAsync()
        {
            return await DbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<AttributeValue> GetAsync(int id)
        {
            FilterDefinition<AttributeValue> filter = filterBuilder.Eq(entity => entity.AttributeValueId, id);
            return await DbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(AttributeValue attr)
        {
            if (attr == null)
            {
                throw new ArgumentNullException(nameof(attr));
            }

            await DbCollection.InsertOneAsync(attr);
        }

        public async Task UpdateAsync(AttributeValue attr)
        {
            if (attr == null)
            {
                throw new ArgumentNullException(nameof(attr));
            }

            FilterDefinition<AttributeValue> filter = filterBuilder.Eq(c=> c.AttributeValueId,attr.AttributeId);
            await DbCollection.ReplaceOneAsync(filter, attr);
        }

        public async Task RemoveAsync(int id)
        {

            FilterDefinition<AttributeValue> filter = filterBuilder.Eq(entity => entity.AttributeValueId, id);
            await DbCollection.DeleteOneAsync(filter);
            {

            }
        }


    
}

}