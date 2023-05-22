using System.ComponentModel.DataAnnotations;

namespace UdemyClone.Models
{
    public class ProductAttribute
    {
        [Key]
        public int ProductAttributeId { get; set; }
        public int Id { get; set; }
        public int AttributeValueId { get; set; }
       
        public AttributeValue attributevalue { get; set; }
        public Product product { get; set; }
    }
}
