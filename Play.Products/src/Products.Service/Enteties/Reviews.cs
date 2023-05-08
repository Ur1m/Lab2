using System;

namespace Play.Products.Service.Enteties
{

    public class Reviews : IEntity
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public Guid UserId { get; set; }
        public Items Items { get; set; }
        public Items ItemsId { get; set; }
    }
}