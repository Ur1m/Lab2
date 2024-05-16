﻿using AutoMapper;
using Event.ProductsContract;
using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserCourseInteraction.Models;
using UserCourseInteraction.Repositories;
using UserCourseInteraction.ViewModels;
using static System.Net.WebRequestMethods;

namespace UserCourseInteraction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private IRepository<ShoppingCart> _reposiory;
        private IRepository<ProductDto> _reposioryProductDto;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public ShoppingCartController(IRepository<ShoppingCart> repository, ISendEndpointProvider sendEndpointProvider, IRepository<ProductDto> reposioryProductDto)
        {
            _reposiory = repository;
            _sendEndpointProvider = sendEndpointProvider;
            _reposioryProductDto = reposioryProductDto;
        }

        [HttpGet]
        public ActionResult<List<ShoppingCartViewModel>> getAll()
        {
            var all = _reposiory.GetAll();

            if (all == null)
            {
                return NotFound();
            }

            return all.Select(x => new ShoppingCartViewModel()
            {
                Id = x.Id,
                userId = x.userId,
                ProductId = x.ProductId
            })
                .ToList();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProductDto>>> getbyIdAsync(string id)
        {
            var all = _reposiory.GetAll().Where(x => x.userId == id);

            if (all == null)
            {
                return NotFound();
            }

            var model = new List<ProductDto>();
            foreach(var item in all)
            {
                var prod = _reposioryProductDto.GetAll().Where(x => x.Id == item.ProductId).FirstOrDefault();

                model.Add(new ProductDto()
                {
                    Id = prod.Id,
                    Desctription = prod.Desctription,
                    CategoryId = prod.CategoryId,
                    CreateDate = prod.CreateDate,
                    Image = prod.Image,
                    Name = prod.Name,
                    Price = prod.Price
                });
            }
            return model;
        }
        
        [HttpPost]
        public ActionResult Add(ShoppingCartViewModel model)
        {
            var shop = new ShoppingCart();

            shop.userId = model.userId;
            shop.ProductId = model.ProductId;

            _reposiory.Add(shop);

            return Ok();
        }
        
        [HttpPut("{Id}")]
        public ActionResult Update(int Id,ShoppingCartViewModel model)
        {
            if(ModelState.IsValid)
            {
                var temp = _reposiory.GetAll().Where(x => x.Id == Id).FirstOrDefault();

                temp.ProductId = model.ProductId;
                temp.userId = model.userId;

                _reposiory.Update(temp);
                
                return Ok();
            }

            return NotFound(); 
        }
      
        [HttpDelete("{Id}")]
        public ActionResult Remove(int Id)
        {
            if (ModelState.IsValid)
            {
                var temp = _reposiory.GetAll().Where(x => x.Id == Id).FirstOrDefault();
               
                _reposiory.Remove(temp);

                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("clear")]
        public ActionResult ClearCart()
        {
            var allItems = _reposiory.GetAll();

            foreach (var item in allItems)
            {
                _reposiory.Remove(item);
            }

            return Ok();
        }



        [HttpPost("purchaseProduct")]
        public async Task<ActionResult> PurchaseProduct(ProcessPaymentDto productDto)
        {

            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:ProcessPayment"));
            await endpoint.Send(productDto);


            return Ok(productDto);
        }
    }
}
