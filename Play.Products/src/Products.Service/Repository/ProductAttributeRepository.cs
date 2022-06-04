using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Play.Products.Service.Enteties;
namespace Play.Products.Service.Repository
{
    public class ProductAttributeRepository:IProductAttributeRepository
    {
         private readonly IMongoCollection<ProductAttribute> DbCollection;
        private readonly FilterDefinitionBuilder<ProductAttribute> filterBuilder = Builders<ProductAttribute>.Filter;

        public ProductAttributeRepository(IMongoDatabase database, string collectionName)
        {
            DbCollection = database.GetCollection<ProductAttribute>(collectionName);
        }

        public async Task<IReadOnlyCollection<ProductAttribute>> GetAllAsyncByProductId()
        {
            
            return await DbCollection.Find(filterBuilder.Empty).ToListAsync();


        }



        public async Task CreateAsync(ProductAttribute entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await DbCollection.InsertOneAsync(entity);
        }

       

        public async Task RemoveAsyc(Guid prodid,Guid attrId)
        {

            FilterDefinition<ProductAttribute> filter = filterBuilder.Eq(entity => entity.ProductId,prodid) ;
            await DbCollection.DeleteOneAsync(filter);
            {

            }
        }

    }
}