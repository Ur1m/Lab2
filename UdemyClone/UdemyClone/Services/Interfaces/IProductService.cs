using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyClone.DTO;
using UdemyClone.Models;

namespace UdemyClone.Services.Interfaces
{
    public interface IProductService
    {
        public List<ProductDTO> GetProducts();
        public ProductDTO GetProductById(int id);
        public void AddProduct(ProductDTO prodDTO);
        public void UpdateProduct(ProductDTO prodDTO);
        public void DeleteProduct(int id);
    }
}
