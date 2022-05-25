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
    [Route("category")]
    public class CategoryController : ControllerBase
    {

        private readonly IRepository<Category> categoryRepository;
        public CategoryController(IRepository<Category> categoryRepository)
        {

            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetAsync()
        {
            var items = (await categoryRepository.GetAllAsync())
                        .Select(items => items.AsCategoryDto());
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetByIdAsync(Guid id)
        {
            var item = await categoryRepository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsCategoryDto();
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> PostAsync(CreateItemDto createItemDto)
        {

            var item = new Category
            {
                Name = createItemDto.Name,
                Desctription = createItemDto.Description
            };

            await categoryRepository.CreateAsync(item);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateCategoryDto updateCategoryDto)
        {
            var existingItem = await categoryRepository.GetAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = updateCategoryDto.Name;
            existingItem.Desctription = updateCategoryDto.Description;

            await categoryRepository.UpdateAsync(existingItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletAsync(Guid id)
        {
            var existingItem = await categoryRepository.GetAsync(id);

            await categoryRepository.RemoveAsyc(existingItem.Id);

            return NoContent();
        }
    }
}