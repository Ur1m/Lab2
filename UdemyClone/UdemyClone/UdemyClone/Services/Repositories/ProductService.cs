using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyClone.Database;
using UdemyClone.DTO;
using UdemyClone.Models;
using UdemyClone.Services.Interfaces;

namespace UdemyClone.Services.Repositories
{
    public class ProductService : IProductService
    {
        private ProductDB _db;
        private IMapper _mapper;

        public ProductService(ProductDB db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void AddProduct(ProductDTO prodDTO)
        {
            try
            {
                var product = new Product();
                
                product = _mapper.Map<Product>(prodDTO);

                product.CreateDate = DateTime.Now;
                product.CategoryId = 5;

                _db.products.Add(product);
                _db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteProduct(int id)
        {
            var prod = _db.products.Where(x => x.Id == id).FirstOrDefault();

            _db.products.Remove(prod);
            _db.SaveChanges();
        }

        public ProductDTO GetProductById(int id)
        {
            var prod= _db.products.Where(x => x.Id == id).Include(x=> x.Category).FirstOrDefault();
            
            var prodDTO = _mapper.Map<ProductDTO>(prod);

            return prodDTO;
        }

        public List<ProductDTO> GetProducts()
        {
            var products = _db.products.Include(x=> x.Category).Select(x=> new ProductDTO
            { 
                Id=x.Id,
                Name=x.Name,
                Desctription=x.Desctription,
                Image=x.Image,
                Price = x.Price,
                CategoryId=x.CategoryId,
                CreateDate=x.CreateDate,
                Category=x.Category
            });
          
            return products.ToList();
        }

        public void UpdateProduct(ProductDTO prodDTO)
        {
            var prod = _mapper.Map<Product>(prodDTO);

            _db.products.Update(prod);
            _db.SaveChanges();
        }
    }
}
