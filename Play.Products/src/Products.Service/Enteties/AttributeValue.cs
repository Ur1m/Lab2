using System;
namespace Play.Products.Service.Enteties
{
    public class AttributeValue
    {
        public Guid AttributeValueId{get;set;}
        public Guid AttributeId{get;set;}
        public string Value{get;set;}
        public Play.Products.Service.Enteties.Attribute Attributee{get;set;}


    }
}