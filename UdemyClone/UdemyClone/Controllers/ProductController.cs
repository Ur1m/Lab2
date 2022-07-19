using MassTransit;
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
    public class ProductController : ControllerBase
    {

        private IProductService _productService;
        private IPublishEndpoint _publishEndpoint;
        public ProductController(IProductService productService,IPublishEndpoint publishEndpoint)
        {
            _productService = productService;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetProducts()
        {
            var prod = _productService.GetProducts();
            if (prod == null)
            {
                return BadRequest();
            }
            return Ok(prod);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductByid(int id)
        {
            var categ = _productService.GetProductById(id);
            if (categ == null)
            {
                return BadRequest();
            }
            return Ok(categ);
        }
        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductDTO prodDTO)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(prodDTO);
                return Ok();

            }
            return BadRequest();

        }
        [HttpPut]
        public async Task<ActionResult> UpdateProduct(ProductDTO prodDTO)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(prodDTO);
                return Ok();

            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<ActionResult> deleteProduct(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            _productService.DeleteProduct(id);
            return Ok();

        }
    }
}
