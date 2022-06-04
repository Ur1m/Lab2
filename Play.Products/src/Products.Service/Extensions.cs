using Play.Products.Service.Enteties;
using Products.Service.Dtos;

namespace Play.Products.Service
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Items item)
        {
            return new ItemDto(item.Id, item.Name,item.Image ,item.Desctription, item.Price, item.CreateDate, item.CategoryId);
        }
        public static CategoryDto AsCategoryDto(this Category item)
        {
            return new CategoryDto(item.Id, item.Name, item.Desctription);
        }
        public static ReviewsDto AsReviewsDto(this Reviews item)
        {
            return new ReviewsDto(item.Id, item.Comment, item.ItemsId);
        }
         public static AttributeDTO AsAttributeDto(this Attribute item)
        {
            return new AttributeDTO(item.AttributeId, item.Name);
        }
         public static AttributeValueDTO AsAttributeValueDto(this AttributeValue item)
        {
            return new AttributeValueDTO(item.AttributeValueId, item.AttributeId,item.Value,item.Attributee);
        }
        public static ProductAttributeDTO AsProductAttributeDto(this ProductAttribute pa)
        {
            return new  ProductAttributeDTO(pa.ProductId,pa.AttributeValueId);
        }
    }
}