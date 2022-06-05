using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyClone.Database;
using UdemyClone.DTO;
using UdemyClone.Models;
using UdemyClone.Services.Interfaces;

namespace UdemyClone.Services.Repositories
{
    public class ReviewService : IReview
    {
        private ProductDB _db;
        private IMapper _mapper;
        public ReviewService(ProductDB db,IMapper maper)
        {
            _db = db;
            _mapper = maper;
        }
        public void AddReview(ReviewDTO prodDTO)
        {
            var rev = _mapper.Map<Review>(prodDTO);

            _db.reviews.Add(rev);
            _db.SaveChanges();

        }

        public void DeleteReview(int id)
        {
            var rev = _db.reviews.Where(x => x.ReviewId == id).FirstOrDefault();
            _db.reviews.Remove(rev);
            _db.SaveChanges();
        }

        public ReviewDTO GetreviewById(int id)
        {
            var rev = _db.reviews.Where(x => x.ReviewId == id).Select(x => _mapper.Map<ReviewDTO>(x)).FirstOrDefault();

            return rev;
        }

        public List<ReviewDTO> GetReviews()
        {
            var rev = _db.reviews.Select(x => _mapper.Map<ReviewDTO>(x)).ToList();
            return rev;
        }

        public List<ReviewDTO> GetReviewsbyProductId(int id)
        {
            var rev = _db.reviews.Where(x=> x.Id==id).Select(x => _mapper.Map<ReviewDTO>(x)).ToList();
            return rev;
        }

        public void UpdateReview(ReviewDTO prodDTO)
        {
            var rev = _mapper.Map<Review>(prodDTO);
            _db.reviews.Update(rev);
            _db.SaveChanges();
        }

       
    }
}
