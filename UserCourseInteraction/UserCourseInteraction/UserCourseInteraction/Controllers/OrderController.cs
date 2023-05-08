using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserCourseInteraction.Repositories;
using UserCourseInteraction.ViewModels;

namespace UserCourseInteraction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

       [HttpGet]
        public async Task<ActionResult<List<OrderViewModel>>> getAllOrders()
        {
            var all = _orderRepository.GetAll();

            if(all==null)
            {
                return NotFound();
            }
            return Ok(all);
        }
        
        [HttpGet("/all/{id}")]
        public async Task<ActionResult<List<OrderViewModel>>> getAllbyId(string Id)
        {
            var all = _orderRepository.getbyUserId(Id);

            if(all==null)
            {
                return NotFound();
            }
            return Ok(all);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderViewModel>> getbyId(int id)
        {
            var order = _orderRepository.getbyId(id);

            if(order==null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        
        [HttpPost]
        public async Task<ActionResult> add(OrderViewModel order)

        {
            if(ModelState.IsValid)
            {
                _orderRepository.Add(order);
                return Ok();
            }
            return NotFound();
        }
        
        [HttpPut]
        public async Task<ActionResult> update(OrderViewModel order)

        {
            if (ModelState.IsValid)
            {
                _orderRepository.Update(order);
                return Ok();
            }
            return NotFound();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(int Id)

        {
            if (Id == 0)
            {
                return NotFound();
            }
            _orderRepository.Remuve(Id);
            return Ok();
        }
    }
}
