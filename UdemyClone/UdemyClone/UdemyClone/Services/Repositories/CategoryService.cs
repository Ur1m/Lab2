using AutoMapper;
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
    public class CategoryService : ICategoryService
    {

        private ProductDB _context;
        private IMapper _mapper;
        public CategoryService(ProductDB context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void DeleteCategory(int id)
        {
          
            var categ = _context.categories.Where(x => x.CategoryId == id).FirstOrDefault();

            if(categ!=null)
            {
                _context.categories.Remove(categ);
                _context.SaveChanges();
            }
        }

        public List<CategoryDTO> GetCategories()
        {
            try
            {
                var categories = _context.categories.Select(x=> new CategoryDTO
                { 
                CategoryId=x.CategoryId,
                Name=x.Name,
                Desctription=x.Desctription}).ToList();
               

                return categories;
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public CategoryDTO GetCategoryById(int id)
        {
            try
            {
                var categ = _context.categories.Where(x => x.CategoryId == id).Select(x=> new CategoryDTO
                {
                    CategoryId=x.CategoryId,
                    Name=x.Name,
                   Desctription=x.Desctription
                }
                ).FirstOrDefault();
                
                return categ;
            }
           catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCategory(CategoryDTO categoryDTO)
        {
            var categ = new Category();
            categ.CategoryId=categoryDTO.CategoryId;
            categ.Name = categoryDTO.Name;
            categ.Desctription = categoryDTO.Desctription;

            _context.categories.Update(categ);
            _context.SaveChanges();
        }

        void ICategoryService.AddCategory(CategoryDTO categoryDTO)
        {
            var categ = _mapper.Map<Category>(categoryDTO);

            _context.categories.Add(categ);
            _context.SaveChanges();
        }
    }
}
