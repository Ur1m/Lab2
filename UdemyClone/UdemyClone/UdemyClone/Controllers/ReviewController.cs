using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyClone.DTO;
using UdemyClone.Services.Interfaces;
using UdemyClone.Services.Repositories;

namespace UdemyClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private IReview _reviewRepository;
        public ReviewController(IReview rev)
        {
            _reviewRepository = rev;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReviewDTO>>> GetReviews()
        {
            var rev = _reviewRepository.GetReviews();
            if (rev == null)
            {
                return BadRequest();
            }
        
            return Ok(rev);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDTO>> GetReviewbyProdId(int id)
        {
            var rev= _reviewRepository.GetReviewsbyProductId(id);
            if (rev == null)
            {
                return BadRequest();
            }
        
            return Ok(rev);
        }

        [HttpPost]
        public async Task<ActionResult> AddReview(ReviewDTO revDTO)
        {
            if (ModelState.IsValid)
            {
                _reviewRepository.AddReview(revDTO);
                return Ok();
            }
            
            return BadRequest();
        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateProduct(ReviewDTO revDTO)
        {
            if (ModelState.IsValid)
            {
               _reviewRepository.UpdateReview(revDTO);
                return Ok();
            }
            
            return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult> deleteProduct(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            _reviewRepository.DeleteReview(id);
            return Ok();
        }
    }
}
