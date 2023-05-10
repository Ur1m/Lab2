using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserCourseInteraction.Models;
using UserCourseInteraction.Repositories;
using UserCourseInteraction.ViewModels;

namespace UserCourseInteraction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private IRepository<WishList> _reposiory;

        public WishListController(IRepository<WishList> repository)
        {
            _reposiory = repository;
        }

        [HttpGet]
        public ActionResult<List<WishListViewModel>> getAll()
        {
            var wishLists = _reposiory.GetAll();
         
            if (wishLists == null)
            {
                return NotFound();
            }
            
            return wishLists.Select(x => new WishListViewModel()
            {
                Id = x.Id,
                userId = x.userId,
                productId=x.productId
            }).ToList();
        }
        
        [HttpGet("{id}")]
        public ActionResult<List<WishListViewModel>> getbyId(string id)
        {
            var all = _reposiory.GetAll().Where(x => x.userId == id);

            if (all == null)
            {
                return NotFound();
            }

            return all.Select(x => new WishListViewModel()
            {
                Id = x.Id,
                userId = x.userId,
                productId = x.productId
            }).ToList();
        }

        [HttpPost]
        public ActionResult Add(WishListViewModel model)
        {
            var shop = new WishList();

            shop.userId = model.userId;
            shop.productId = model.productId;
            
            _reposiory.Add(shop);
            
            return Ok();
        }

        [HttpPut("{Id}")]
        public ActionResult Update(int Id, WishListViewModel model)
        {
            if (ModelState.IsValid)
            {
                var temp = _reposiory.GetAll().Where(x => x.Id == Id).FirstOrDefault();

                temp.productId= model.productId;
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

