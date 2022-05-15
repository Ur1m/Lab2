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
                var categories = _context.categories.ToList();
                var categoriesDto = new List<CategoryDTO>();
               categoriesDto =_mapper.Map<List<CategoryDTO>>( categories);

                return categoriesDto;
                
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
                var categ = _context.categories.Where(x => x.CategoryId == id).FirstOrDefault();
                var categDto = _mapper.Map<CategoryDTO>(categ);
                return categDto;
            }
           catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCategory(CategoryDTO categoryDTO)
        {
            var categ = _mapper.Map<Category>(categoryDTO);

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
