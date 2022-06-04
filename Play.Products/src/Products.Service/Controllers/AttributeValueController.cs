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
    [Route("attributevalues")]
    public class AttributeValueController:ControllerBase
    {
         private readonly IAttributeValueRepository _attributeValueRepository;
        public AttributeValueController(IAttributeValueRepository attrvaluerepository)
        {

           
            _attributeValueRepository=attrvaluerepository;

        }
         [HttpGet]
       public async Task<IEnumerable<AttributeValueDTO>> GetAttrValuesAsync(Guid id)
       {
            var items = (await _attributeValueRepository.GetAllAttrValuesAsync(id))
                       .Select(items => items.AsAttributeValueDto());
          return (IEnumerable<AttributeValueDTO>)items;
       }
        [HttpGet("{id}")]
        public async Task<ActionResult<AttributeValueDTO>> GetAttrValueByIdAsync(Guid id)
        {
            var item = await _attributeValueRepository.GetAttrValueAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsAttributeValueDto();
        }

         [HttpPost]
        public async Task<IActionResult> PostAsync(AttributeValueDTO createItemDto)
        {

            var item = new AttributeValue
            {
                AttributeValueId= createItemDto.AttributeValueId,
                AttributeId=createItemDto.AttributeId,
                Value = createItemDto.Value,
                Attributee=null
            };

            await _attributeValueRepository.CreateAsync(item);

            return NoContent();
        }
         [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, AttributeValueDTO updateattrDto)
        {
            var existingItem = await _attributeValueRepository.GetAttrValueAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.AttributeId= updateattrDto.AttributeId;
            existingItem.Value=updateattrDto.Value;
            existingItem.Attributee=null;
            

            await _attributeValueRepository.UpdateAttrValueAsync(existingItem);

            return NoContent();
        }



        
    }
}