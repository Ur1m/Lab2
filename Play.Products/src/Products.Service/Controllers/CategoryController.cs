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

        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {

           _categoryRepository=categoryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetAsync()
        {
            var items = (await _categoryRepository.GetAllAsync())
                        .Select(items => items.AsCategoryDTO());
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetByIdAsync(int id)
        {
            var item = await _categoryRepository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsCategoryDTO();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CategoryDTO categoryDto)
        {

            var item = new Category
            {
                CategoryId=categoryDto.CategoryId,
                Name=categoryDto.Name,
                Description=categoryDto.Description,
                Image=categoryDto.Image,
                IsDeleted=categoryDto.IsDeleted
            };

            await _categoryRepository.CreateAsync(item);

            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, CategoryDTO categoryDto)
        {
            var existingItem = await _categoryRepository.GetAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }

             existingItem.CategoryId = categoryDto.CategoryId;
              existingItem.Name = categoryDto.Name;
               existingItem.Description = categoryDto.Description;
            existingItem.Image = categoryDto.Image;
               existingItem.IsDeleted = categoryDto.IsDeleted;

            await _categoryRepository.UpdateAsync(existingItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletAsync(int id)
        {
           

            await _categoryRepository.RemoveAsyc(id);

            return NoContent();
        }
    }
}