using System;
using System.ComponentModel.DataAnnotations;

namespace Play.Products.Service.Enteties
{
    public class AttributeValue
    {
        public int AttributeValueId{get;set;}
        public string Value{get;set;}
        public int AttributeId{get;set;}
        public Attribute Attribute{get;set;}
        
    }
}