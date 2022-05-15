using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyClone.DTO;

namespace UdemyClone.Services.Interfaces
{
    public interface ICategoryService
    {
        public List<CategoryDTO> GetCategories();
        public CategoryDTO GetCategoryById(int id);
        public void AddCategory(CategoryDTO categoryDTO);
        public void UpdateCategory(CategoryDTO categoryDTO);
        public void DeleteCategory(int id);
    }
}
