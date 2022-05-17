
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
    [Route("attribute")]
    public class AttributeController : ControllerBase
    {

        private readonly IAttributeRepository _attrRepository;
       
        public AttributeController(IAttributeRepository attrRepository)
        {

           _attrRepository=attrRepository;
          
        }

        [HttpGet]
        public async Task<IEnumerable<AttributeDTO>> GetAsync()
        {
            var items = (await _attrRepository.GetAllAsync())
                        .Select(items => items.AsAttributeDTO());
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttributeDTO>> GetByIdAsync(int id)
        {
            var item = await _attrRepository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsAttributeDTO();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(AttributeDTO attr)
        {

            var item = new Attribute
            {
                AttributeId=attr.AttributeId,
                Name=attr.Name,
               
            };

            await _attrRepository.CreateAsync(item);

            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, AttributeDTO attr)
        {
            var existingItem = await _attrRepository.GetAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }
            existingItem.Name=attr.Name;
               

            await _attrRepository.UpdateAsync(existingItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletAsync(int id)
        {
           

            await _attrRepository.RemoveAsync(id);

            return NoContent();
        }
    }
}