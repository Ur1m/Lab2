using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Play.Products.Service;
using Play.Products.Service.Enteties;
using Play.Products.Service.Repository;
using Products.Service.Dtos;


namespace Products.Service.Controllers
{

    [ApiController]
    [Route("reviews")]
    public class ReviewsController : ControllerBase
    {

        private readonly IReviewsRepository _reviewsRepository;
        public ReviewsController(IReviewsRepository reviewsRepository)
        {

          _reviewsRepository=reviewsRepository;
        }

        [HttpGet("/likes/{id}")]
        public async Task<IEnumerable<ReviewsDTO>> GetAllLikesAsync(int id)
        {
            var items = (await _reviewsRepository.GetAllLikesAsync(id))
                        .Select(items => items.AsReviewsDTO());
            return items;
        }
         [HttpGet("/dislikes/{id}")]
        public async Task<IEnumerable<ReviewsDTO>> GetAllDislikesAsync(int id)
        {
            var items = (await _reviewsRepository.GetAllDislikesAsync(id))
                        .Select(items => items.AsReviewsDTO());
            return items;
        }
          [HttpGet("/rates/{id}")]
        public async Task<IEnumerable<ReviewsDTO>> GetAllRatesAsync(int id)
        {
            var items = (await _reviewsRepository.GetAllRatesAsync(id))
                        .Select(items => items.AsReviewsDTO());
            return items;
        }
         [HttpGet("/comments/{id}")]
        public async Task<IEnumerable<ReviewsDTO>> GetAllCommentsAsync(int id)
        {
            var items = (await _reviewsRepository.GetAllCommentsAsync(id))
                        .Select(items => items.AsReviewsDTO());
            return items;
        }
        [HttpGet("{id}")]
       

        [HttpPost]
        public async Task<IActionResult> PostAsync(ReviewsDTO rev)
        {

            var item = new Reviews
            {
              UserId=rev.UserId,
              CourseId=rev.CourseId,
              NumberOfStarts=rev.NumberOfStarts,
              Like=rev.Like,
              Dislike=rev.Dislike,
              Comment=rev.Comment
            };

            await _reviewsRepository.AddAsync(item);

            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, ReviewsDTO rev)
        {
            var existingItem = await _reviewsRepository.GetById(id);

            if (existingItem == null)
            {
                return NotFound();
            }

             existingItem.UserId = rev.UserId;
              existingItem.CourseId = rev.CourseId;
               existingItem.NumberOfStarts = rev.NumberOfStarts;
            existingItem.Like = rev.Like;
               existingItem.Dislike = rev.Dislike;
               existingItem.Comment=rev.Comment;

            await _reviewsRepository.UpdateAsync(existingItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletAsync(int id)
        {
           

            await _reviewsRepository.RemoveAsyc(id);

            return NoContent();
        }
    }
}