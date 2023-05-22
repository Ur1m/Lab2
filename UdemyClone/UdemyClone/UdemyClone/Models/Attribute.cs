using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyClone.Models
{
    public class Attribute
    {
        [Key]
        public int AttributeId { get; set; }
        public string Name { get; set; }
    }
}
