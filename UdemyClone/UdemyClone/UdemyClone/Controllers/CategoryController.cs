using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyClone.DTO;
using UdemyClone.Services.Interfaces;

namespace UdemyClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> GetCategories()
        {
            var categ = _categoryService.GetCategories();

            if(categ==null)
            {
                return BadRequest();
            }

            return Ok(categ);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            var categ = _categoryService.GetCategoryById(id);

            if (categ == null)
            {
                return BadRequest();
            }

            return Ok(categ);
        }
        
        [HttpPost]
        public async Task<ActionResult> AddCategory(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                _categoryService.AddCategory(categoryDTO);

                return Ok();
            }
            
            return BadRequest();
        }
        
        [HttpPut]
        public async Task<ActionResult>UpdateCategory(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                _categoryService.UpdateCategory(categoryDTO);

                return Ok();
            }
            
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteCategory(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            _categoryService.DeleteCategory(id);

            return Ok();
        }
    }
}
