using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Play.Products.Service.Enteties;

namespace Play.Products.Service.Repository
{
	public class ReviewsRepository : IReviewsRepository
	{

        private readonly IMongoCollection<Reviews> DbCollection;
        private readonly FilterDefinitionBuilder<Reviews> filterBuilder = Builders<Reviews>.Filter;

        public ReviewsRepository(IMongoDatabase database, string collectionName)
        {
            DbCollection = database.GetCollection<Reviews>(collectionName);
        }

        public async Task<IReadOnlyCollection<Reviews>> GetAllLikesAsync(int id)
        {
            return await DbCollection.Find(x=> x.CourseId==id && x.Like==true).ToListAsync();
        }
         public async Task<IReadOnlyCollection<Reviews>> GetAllRatesAsync(int id)
        {
            return await DbCollection.Find(x=> x.CourseId==id && x.NumberOfStarts>0).ToListAsync();
        }
       
        public async Task<IReadOnlyCollection<Reviews>> GetAllDislikesAsync(int id)
        {
            return await DbCollection.Find(x=> x.CourseId==id && x.Dislike==true).ToListAsync();
        }
          public async Task<IReadOnlyCollection<Reviews>> GetAllCommentsAsync(int id)
        {
            return await DbCollection.Find(x=> x.CourseId==id && x.Comment!=null).ToListAsync();
        }
        public async Task<Reviews> GetById(int id)
        {
             FilterDefinition<Reviews> filter = filterBuilder.Eq(entity => entity.Id, id);
            return await DbCollection.Find(filter).FirstOrDefaultAsync();

        }

       

        public async Task AddAsync(Reviews rev )
        {
            if (rev == null)
            {
                throw new ArgumentNullException(nameof(rev));
            }

            await DbCollection.InsertOneAsync(rev);
        }

        public async Task UpdateAsync(Reviews rev)
        {
            if (rev == null)
            {
                throw new ArgumentNullException(nameof(rev));
            }

            FilterDefinition<Reviews> filter = filterBuilder.Eq(entity => entity.Id,rev.Id );
            await DbCollection.ReplaceOneAsync(filter, rev);
        }

        public async Task RemoveAsyc(int id)
        {

            FilterDefinition<Reviews> filter = filterBuilder.Eq(entity => entity.Id, id);
            await DbCollection.DeleteOneAsync(filter);
            {

            }
        }


    
}

}