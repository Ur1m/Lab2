using System;

namespace Play.Products.Service.Enteties
{

    public class Items : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Desctription { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public Category Category{get;set;}
        public Category CategoryId {get;set;}
    }
}