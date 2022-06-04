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
    [Route("Attribute")]
    public class AttributeController : ControllerBase
    {

        private readonly IAttributeRepository _attributeRepository;
        private readonly IAttributeValueRepository _attributeValueRepository;
        public AttributeController(IAttributeRepository attributeRepository,IAttributeValueRepository attrvaluerepository)
        {

            _attributeRepository = attributeRepository;
            _attributeValueRepository=attrvaluerepository;

        }

        [HttpGet]
        public async Task<IEnumerable<AttributeDTO>> GetAsync()
        {
            var items = (await _attributeRepository.GetAllAsync())
                        .Select(items => items.AsAttributeDto());
            return items;
        }

       

        [HttpGet("{id}")]
        public async Task<ActionResult<AttributeDTO>> GetByIdAsync(Guid id)
        {
            var item = await _attributeRepository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsAttributeDto();
        }
         

       
        [HttpPost]
        public async Task<IActionResult> PostAsync(AttributeDTO createItemDto)
        {

            var item = new  Play.Products.Service.Enteties.Attribute
            {
                AttributeId= createItemDto.AttributeId,
                Name= createItemDto.Name
            };

            await _attributeRepository.CreateAsync(item);

            return NoContent();

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, AttributeDTO updateCategoryDto)
        {
            var existingItem = await _attributeRepository.GetAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = updateCategoryDto.Name;
            

            await _attributeRepository.UpdateAsync(existingItem);

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletAsync(Guid id)
        {
            var existingItem = await _attributeValueRepository.GetAttrValueAsync(id);

            await _attributeValueRepository.RemoveAttrValueAsyc(existingItem.AttributeValueId);

            return NoContent();
        }
    }
}