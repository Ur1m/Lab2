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
    [Route("course")]
    public class CourseController : ControllerBase
    {

        private readonly ICourseRepository _courseRepository;
        private readonly ICategoryRepository _categoryRepository;
        public CourseController(ICourseRepository courseRepository,ICategoryRepository categoryRepository)
        {

           _courseRepository=courseRepository;
           _categoryRepository=categoryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseDTO>> GetAsync()
        {
            var items = (await _courseRepository.GetAllAsync())
                        .Select(items => items.AsCourseDTO());
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> GetByIdAsync(int id)
        {
            var item = await _courseRepository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsCourseDTO();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CourseDTO courseDto)
        {

            var item = new Course
            {
                CourseId=courseDto.CategoryId,
                Name=courseDto.Name,
                Description=courseDto.Description,
                Image=courseDto.Image,
                Difficulty=courseDto.Difficulty,
                CourseContent=courseDto.CourseContent,
                CategoryId=courseDto.CategoryId,
                IsDeleted=courseDto.IsDeleted,
                Category=await _categoryRepository.GetAsync(courseDto.CategoryId),
                CreatedOn=DateTime.Now
            };

            await _courseRepository.CreateAsync(item);

            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, CourseDTO courseDto)
        {
            var existingItem = await _courseRepository.GetAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }
             if(courseDto.CategoryId!=existingItem.CategoryId)
             {
                 existingItem.Category= await _categoryRepository.GetAsync(courseDto.CategoryId);
             }
             existingItem.CategoryId = courseDto.CategoryId;
              existingItem.Name = courseDto.Name;
               existingItem.Description = courseDto.Description;
            existingItem.Image = courseDto.Image;
               existingItem.IsDeleted = courseDto.IsDeleted;
               existingItem.CourseContent=courseDto.CourseContent;
               

            await _courseRepository.UpdateAsync(existingItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletAsync(int id)
        {
           

            await _courseRepository.RemoveAsync(id);

            return NoContent();
        }
    }
}