using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyClone.DTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
