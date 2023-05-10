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
    public class AttributeController : ControllerBase
    {
        private IAttributeRepository _attrbuteRepository;

        public AttributeController(IAttributeRepository attributeRepository)
        {
            _attrbuteRepository = attributeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AttributeDTO>>> getAtrDto()
        {
            var atrs = _attrbuteRepository.getAllAtributes();
            if (atrs == null)
            {
                return NotFound();
            }
            return Ok(atrs);
        }

        [HttpGet("attributevalues")]
        public async Task<ActionResult<List<AttributeDTO>>> getAllAtributeVAlues()
         {
            var atrvalues = _attrbuteRepository.getAllAtrvalues();

            if(atrvalues==null)
            {
                return NotFound();
            }

            return Ok(atrvalues);
         }

        [HttpGet("atributevalues/{id}")]
        public async Task<ActionResult<List<AttributeValueDTO>>> getvalues(int id)
        {
            var val = _attrbuteRepository.getAttributeVAluesByAttributeId(id);

            if (val == null)
            {
                return NotFound();
            }

            return Ok(val);
        }

        [HttpGet("productvalues/{id}")]
        public async Task<ActionResult<List<AttributeValueDTO>>> getprodvalues(int id)
        {
            var val = _attrbuteRepository.getAttributeValuesByProductId(id);

            if (val == null)
            {
                return NotFound();
            }

            return Ok(val);
        }

        [HttpPost]
        public async Task<ActionResult> addAtribute(AttributeDTO atr)
        {
            _attrbuteRepository.AddAtribute(atr);

            return Ok();
        }
        
        [HttpPost("addvalue")]
        public async Task<ActionResult> addatrvalue(AttributeValueDTO atrval)
        {
            _attrbuteRepository.AddAttributeValue(atrval);

            return Ok();
        }

        [HttpPost("addprodatr/{prodId}/{valId}")]
        public async Task<ActionResult> addprodatr(int prodId, int valId)
        {
            var product = new ProductAttributeDTO();

            product.Id = prodId;
            product.AttributeValueId = valId;

            _attrbuteRepository.AddProductAttr(product);

            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteattr(int id)
        {
            _attrbuteRepository.DeleteAttribute(id);

            return Ok();
        }

        [HttpDelete("atrvalue/{id}")]
        public async Task<ActionResult> deleteattrvalue(int id)
        {
            _attrbuteRepository.DeleteAttributeValue(id);

            return Ok();
        }

        [HttpDelete("prodatr/{prodId}/{atrId}")]
        public async Task<ActionResult> deleteattr(int prodId, int atrId)
        {
            _attrbuteRepository.DeleteAttributeValueForProduct(prodId, atrId);

            return Ok();
        }
        
        [HttpGet("productbyatribute/{id}")]
        public async Task<ActionResult> getprods(int id)
        {
            var prods = _attrbuteRepository.getProductbyAttributeValue(id);

            return Ok(prods);
        }
    }
}
