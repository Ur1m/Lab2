using System;

namespace Play.Products.Service.Enteties
{

    public class Category : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Desctription { get; set; }

    }
}