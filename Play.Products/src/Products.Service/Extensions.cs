using Play.Products.Service.Enteties;
using Products.Service.Dtos;

namespace Play.Products.Service
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Items item)
        {
            return new ItemDto(item.Id, item.Name, item.Desctription, item.Price, item.CreateDate);
        }
    }
}