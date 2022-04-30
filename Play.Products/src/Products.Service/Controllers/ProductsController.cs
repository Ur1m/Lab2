using System;
using System.Collections.Generic;
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

    }
}