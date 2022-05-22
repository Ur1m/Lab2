using Play.Products.Service.Enteties;
using Products.Service.Dtos;

namespace Play.Products.Service
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Items item)
        {
            return new ItemDto(item.Id, item.Name, item.Desctription, item.Price, item.CreateDate);
        }
        public static CategoryDTO AsCategoryDTO(this Category category)
        {
            return new CategoryDTO(category.CategoryId,category.Name,category.Description,category.Image,category.DisplayOrder,category.IsDeleted);
        }
         public static CourseDTO AsCourseDTO(this Course course)
        {
            return new CourseDTO(course.CourseId,course.Name,course.Description,course.Image,course.Difficulty,course.CourseContent,course.CreatedOn,course.IsDeleted,course.CategoryId,course.Category);
        }
         public static AttributeDTO AsAttributeDTO(this Attribute attr)
        {
            return new AttributeDTO(attr.AttributeId,attr.Name);
        }

         public static AttributeValueDTO AsAttributeValueDTO(this AttributeValue attrvalue)
        {
            return new AttributeValueDTO(attrvalue.AttributeValueId,attrvalue.Value,attrvalue.AttributeId,attrvalue.Attribute);
        }
    }
}