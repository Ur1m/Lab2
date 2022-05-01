using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Products.Service.Dtos;

namespace Products.Service.Controllers
{

    [ApiController]
    [Route("products")]
    public class ProductsCrontroller : ControllerBase
    {

        private static readonly List<ItemDto> items = new(){

            new ItemDto(Guid.NewGuid(), "Java Course","Java course for beginners",50,DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "JavaScript Course","JavaScript course for beginners",50,DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "C#","C# course for beginners",60,DateTimeOffset.UtcNow)
        };

        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetById(Guid id)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public ActionResult<ItemDto> Post(CreateItemDto createItemDto)
        {
            var item = new ItemDto(Guid.NewGuid(), createItemDto.Name, createItemDto.Description, createItemDto.Price, DateTimeOffset.UtcNow);
            items.Add(item);

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);

        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, UpdateItemDto updateItemDto)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();

            if (item == null)
            {
                return NotFound();
            }

            var updateItem = item with
            {
                Name = updateItemDto.Name,
                Description = updateItemDto.Description,
                Price = updateItemDto.Price
            };
            var index = items.FindIndex(item => item.Id == id);
            items[index] = updateItem;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = items.FindIndex(item => item.Id == id);

            if (item < 0)
            {
                return NotFound();
            }
            items.RemoveAt(item);

            return NoContent();
        }
    }
}