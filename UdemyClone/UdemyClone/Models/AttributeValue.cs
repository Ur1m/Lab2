using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyClone.Models
{
    public class AttributeValue
    {
        [Key]
        public int AttributeValueId { get; set; }
        public string Value { get; set; }
        public int AttributeId { get; set; }
        public Attribute attribute { get; set; }

    }
}
