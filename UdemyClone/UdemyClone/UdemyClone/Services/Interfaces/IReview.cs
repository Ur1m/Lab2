using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyClone.DTO;

namespace UdemyClone.Services.Interfaces
{
   public interface IReview
    {
        public List<ReviewDTO> GetReviews();
        public List<ReviewDTO> GetReviewsbyProductId(int id);
        public ReviewDTO GetreviewById(int id);
        public void AddReview(ReviewDTO prodDTO);
        public void UpdateReview(ReviewDTO prodDTO);
        public void DeleteReview(int id);
    }
}
