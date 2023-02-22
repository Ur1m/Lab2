using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
