using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


        public ShoppingCartController(IRepository<ShoppingCart> repository)
        {
            _reposiory = repository;
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
        public async Task<ActionResult<List<ShoppingCartViewModel>>> getbyIdAsync(string id)
        {
            var all = _reposiory.GetAll().Where(x => x.userId == id);

            if (all == null)
            {
                return NotFound();
            }

            var model = new ShoppingCartViewModel();
          
            return all.Select(x => new ShoppingCartViewModel()
            {
                Id = x.Id,
                userId = x.userId,
                ProductId = x.ProductId
            }).ToList();
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
    }
}
