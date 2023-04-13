using AutoMapper;
using Event.ProductsContract;
using Hangfire;
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
        private readonly IMapper _mapper;
        private readonly ISendEndpointProvider _sendEndpointProvider;
        public ProductController(IProductService productService, IPublishEndpoint publishEndpoint, IMapper mapper, ISendEndpointProvider sendEndpointProvider)
        {
            _productService = productService;
            _mapper = mapper;
            _sendEndpointProvider = sendEndpointProvider;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetProducts()
        {
            try {
                var result = new List<ProductDTO>();
                var prod = _productService.GetProducts();
                BackgroundJob.Enqueue(() => _productService.GetProducts());
                return Ok(prod);
            }
            catch (Exception ex)
                {
                return BadRequest();

            }
        }
        [HttpGet("{id}")]
        public ProductDTO GetProductByid(int id)
        {
            var categ = _productService.GetProductById(id);
          
            return categ;
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
        [HttpPost("SendProductToCart")]
        public async Task<ActionResult> SendProductToCart(ShoppingCartViewModel prodDTO)
        {
            var obj = new ShoppingCartViewModel()
            {
                userId = prodDTO.userId,
                ProductId = prodDTO.ProductId
            };

            var obj1 = GetProductByid(prodDTO.ProductId);

            var mappedObj = _mapper.Map<CartEventDto>(obj);
            var mappedObj1 = _mapper.Map<ProductEventDTO>(obj1);

            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:ProductQueue"));
            await endpoint.Send(mappedObj);

            var endpoint1 = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:gg"));
            await endpoint1.Send(mappedObj1);

            return Ok(mappedObj);
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
