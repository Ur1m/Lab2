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
    [Route("products")]
    public class ProductsController : ControllerBase
    {

        private readonly IRepository<Items> itemsRepository;
        private readonly IProductAttributeRepository _Productattrs;
        public ProductsController(IRepository<Items> itemsRepository,IProductAttributeRepository pa)
        {

            this.itemsRepository = itemsRepository;
            _Productattrs=pa;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetAsync()
        {
            var items = (await itemsRepository.GetAllAsync())
                        .Select(items => items.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetByIdAsync(Guid id)
        {
            var item = await itemsRepository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> PostAsync(CreateItemDto createItemDto)
        {

            var item = new Items
            {
                Name = createItemDto.Name,
                Image =createItemDto.Image,
                Desctription = createItemDto.Description,
                Price = createItemDto.Price,
                CreateDate = DateTimeOffset.UtcNow,
                CategoryId = createItemDto.CategoryId
            };

            await itemsRepository.CreateAsync(item);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = await itemsRepository.GetAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = updateItemDto.Name;
            existingItem.Desctription = updateItemDto.Description;
            existingItem.Price = updateItemDto.Price;
            existingItem.CategoryId = updateItemDto.CategoryId;
            existingItem.Image=updateItemDto.Image;

            await itemsRepository.UpdateAsync(existingItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletAsync(Guid id)
        {
            var existingItem = await itemsRepository.GetAsync(id);

            await itemsRepository.RemoveAsyc(existingItem.Id);

            return NoContent();
        }
        [HttpPost("addAttrValue")]
       public async Task<IActionResult> AddAttrValue(ProductAttribute pa)
   {
       await _Productattrs.CreateAsync(pa);
        return NoContent();

   }
     [HttpGet("/attrvaluesforproduct")]
        public async Task<IEnumerable<ProductAttributeDTO>> getAttrValue()
    {
       var atrs= (await _Productattrs.GetAllAsyncByProductId())
          .Select(x=> x.AsProductAttributeDto());

            return (IEnumerable<ProductAttributeDTO>)atrs;
        
   }
    
    [HttpDelete]
        public async Task<IActionResult> DeleteAttrValue(ProductAttributeDTO prod)
    {
        await _Productattrs.RemoveAsyc(prod.ProductId,prod.AttributeValueId);
         
                       return NoContent();

   }
    }
    }


    
