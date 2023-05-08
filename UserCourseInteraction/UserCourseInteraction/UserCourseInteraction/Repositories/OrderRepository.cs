using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserCourseInteraction.Database;
using UserCourseInteraction.Models;
using UserCourseInteraction.ViewModels;

namespace UserCourseInteraction.Repositories
{
    public class OrderRepository : IOrderRepository
    {
      private  ApplicationDbContext _db;
        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(OrderViewModel model)
        {
            var order = new Order() { userId=model.userId,CreatedOn=DateTime.Now,

            totalPrice=model.totalPrice};

            _db.orders.Add(order);

            _db.SaveChanges();

            var id = _db.orders.LastOrDefault().OrderId;

            var listofprod = new List<Product>();

            listofprod = _db.products.ToList();

            var prod = model.products.Where(x => !listofprod.Contains(x)).ToList();

            _db.products.AddRange(prod);

            foreach(var item in model.products)
            {
                var orderitem = new OrderItem()
                {
                    OrderId=id,
                    ProductId=item.productId
                };

                _db.oredrItem.Add(orderitem);
                _db.SaveChanges();
            }
        }

        public List<OrderViewModel> GetAll()
        {
            var model = new List<OrderViewModel>();
         
            var orders = _db.orders.ToList();

            foreach (var order in orders)
            {
                var productIds = _db.oredrItem.Where(x => x.OrderId == order.OrderId).Select(x => x.ProductId).ToList();
            
                var products = new List<Product>();
                
                foreach(var item in productIds)
                {
                   products.Add(_db.products.Where(x => x.productId == item).FirstOrDefault());
                }

                var neworder = new OrderViewModel()
                {
                    OrderId = order.OrderId,
                    userId = order.userId,
                    CreatedOn = order.CreatedOn,
                    totalPrice = order.totalPrice,
                    products = products
                };
                model.Add(neworder);
            }
            return model;
        }

        public OrderViewModel getbyId(int id)
        {
           // var model = new List<OrderViewModel>();
            var orders = _db.orders.Where(x=> x.OrderId==id).FirstOrDefault();
            var productsId = _db.oredrItem.Where(x => x.OrderId == id).ToList();
            var products = new List<Product>();

            foreach(var item in productsId)
            {
                products.Add(_db.products.Where(x => x.productId == item.ProductId).FirstOrDefault());
            }
          
            var productId = _db.oredrItem.Where(x => x.OrderId == orders.OrderId).Select(x => x.ProductId).ToList();
            
            var neworder = new OrderViewModel()
            {
                OrderId = orders.OrderId,
                userId = orders.userId,
                CreatedOn = orders.CreatedOn,
                totalPrice = orders.totalPrice,
                products = products
            };
            
            return neworder;
        }

        public List<OrderViewModel> getbyUserId(string Id)
        {
            var model = new List<OrderViewModel>();
            
            var orders = _db.orders.Where(x=> x.userId==Id).ToList();

            foreach (var order in orders)
            {
                var productId = _db.oredrItem.Where(x => x.OrderId == order.OrderId).Select(x => x.ProductId).ToList();

                var products = new List<Product>();
            
                foreach (var item in productId)
                {
                    products.Add(_db.products.Where(x => x.productId == item).FirstOrDefault());
                }
                
                var neworder = new OrderViewModel()
                {
                    OrderId = order.OrderId,
                    userId = order.userId,
                    CreatedOn = order.CreatedOn,
                    totalPrice = order.totalPrice,
                    products = products
                };
                
                model.Add(neworder);
            }
            return model;
        }

        public void Remuve(int Id)
        {
            var order = _db.orders.Where(x => x.OrderId == Id);
           
            _db.orders.RemoveRange(order);
            _db.SaveChanges();
            
            var orderitem = _db.oredrItem.Where(x => x.OrderId == Id).ToList();
            
            _db.oredrItem.RemoveRange(orderitem);
            _db.SaveChanges();
        }

        public void Update(OrderViewModel model)
        {
            var order = new Order()
            {
                OrderId=model.OrderId,
                userId = model.userId,
                CreatedOn = DateTime.Now,
                totalPrice = model.totalPrice
            };
            _db.orders.Update(order);
            _db.SaveChanges();
           
            var prododucts = _db.oredrItem.Where(x => x.OrderId == model.OrderId).ToList();
            _db.oredrItem.RemoveRange(prododucts);
            _db.SaveChanges();

            var listofprod = new List<Product>();
            listofprod = _db.products.ToList();
            var prod = model.products.Where(x => !listofprod.Contains(x)).ToList();

            _db.products.AddRange(prod);


            foreach (var item in model.products)
            {
                var orderitem = new OrderItem(
                    )
                {
                    OrderId = model.OrderId,
                    ProductId = item.productId
                };

                _db.oredrItem.Add(orderitem);
                _db.SaveChanges();
            }
        }
    }
}
