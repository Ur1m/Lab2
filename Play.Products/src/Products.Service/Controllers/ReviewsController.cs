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

        private readonly IRepository<Reviews> _reviewsRepository;

        public ReviewsController(IRepository<Reviews> reviewsRepository)
        {

            _reviewsRepository= reviewsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ReviewsDto>> GetAsync()
        {
            var items = (await _reviewsRepository.GetAllAsync())
                                                .Select(items => items.AsReviewsDto());
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewsDto>> GetByIdAsync(Guid id)
        {
            var item = await _reviewsRepository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsReviewsDto();
        }

        [HttpPost]
        public async Task<ActionResult<ReviewsDto>> PostAsync(CreateReviewsDto createReviewsDto)
        {

            var item = new Reviews
            {
                Comment = createReviewsDto.Comment,
                ItemsId = createReviewsDto.ItemsId
            };

            await _reviewsRepository.CreateAsync(item);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateReviewsDto updateReviewsDto)
        {
            var existingItem = await _reviewsRepository.GetAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Comment = updateReviewsDto.Comment;

            await _reviewsRepository.UpdateAsync(existingItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletAsync(Guid id)
        {
            var existingItem = await _reviewsRepository.GetAsync(id);

            await _reviewsRepository.RemoveAsyc(existingItem.Id);

            return NoContent();
        }
    }
}