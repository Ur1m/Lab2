using AutoMapper;
using Event.ProductsContract;
using UdemyClone.DTO;

namespace UdemyClone.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<CartEventDto,ShoppingCartViewModel>().ReverseMap();
            CreateMap<ProductEventDTO, ProductDTO>().ReverseMap();
        }
    }
}
