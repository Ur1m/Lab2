
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
        private readonly IAttributeValueRepository _attrvalueRepository;
       
        public AttributeController(IAttributeRepository attrRepository,IAttributeValueRepository AttributeValueRepository)
        {

           _attrRepository=attrRepository;
           _attrvalueRepository=AttributeValueRepository;
          
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
        [HttpGet("/attributevalue")]
        
        public async Task<IEnumerable<AttributeValueDTO>> GetAllAtributeValue()
        {
            var items = (await _attrvalueRepository.GetAllAsync())
                        .Select(items => items.AsAttributeValueDTO());
            return items;
        }

         [HttpGet("/attributevalue/{id}")]
        public async Task<ActionResult<AttributeValueDTO>> GetAttributeValueByIdAsync(int id)
        {
            var item = await _attrvalueRepository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsAttributeValueDTO();
        }

        [HttpPost("attributevalue")]
        public async Task<IActionResult> PostAttrValueAsync(AttributeValueDTO attr)
        {

            var item = new AttributeValue
            {
               Value=attr.Value,
               AttributeId=attr.AttributeId,
             //  Attribute=_attrRepository.GetAsync(attr.AttributeId)
               
            };

            await _attrvalueRepository.CreateAsync(item);

            return NoContent();

        }

        [HttpPut("/attributevalue/{id}")]
        public async Task<IActionResult> PutAttrValueAsync(int id, AttributeValueDTO attr)
        {
            var existingItem = await _attrvalueRepository.GetAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }
            existingItem.Value=attr.Value;
            existingItem.AttributeId=attr.AttributeId;
           // existingItem.Attribute=_attrRepository.GetAsync(attr.AttributeId);
               

            await _attrvalueRepository.UpdateAsync(existingItem);

            return NoContent();
        }

        [HttpDelete("attributevalue/{id}")]
        public async Task<IActionResult> DeletAttributeValueAsync(int id)
        {
           

            await _attrvalueRepository.RemoveAsync(id);

            return NoContent();
        }
    }
}