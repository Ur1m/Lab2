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
        private readonly IRepository<Items> _itemsRepository;

        public ProductsController(IRepository<Items> itemsRepository)
        {
            _itemsRepository= itemsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetAsync()
        {
            var items = (await _itemsRepository.GetAllAsync())
                                              .Select(items => items.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetByIdAsync(Guid id)
        {
            var item = await _itemsRepository.GetAsync(id);

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
                Desctription = createItemDto.Description,
                Price = createItemDto.Price,
                CreateDate = DateTimeOffset.UtcNow,
                CategoryId = createItemDto.CategoryId
            };

            await _itemsRepository.CreateAsync(item);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = await _itemsRepository.GetAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = updateItemDto.Name;
            existingItem.Desctription = updateItemDto.Description;
            existingItem.Price = updateItemDto.Price;
            existingItem.CategoryId = updateItemDto.CategoryId;

            await itemsRepository.UpdateAsync(existingItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletAsync(Guid id)
        {
            var existingItem = await _itemsRepository.GetAsync(id);

            await itemsRepository.RemoveAsyc(existingItem.Id);

            return NoContent();
        }
    }
}