using AutoMapper;
using Event.ProductsContract;
using UdemyClone.DTO;
using UdemyClone.Models;

namespace UdemyClone.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<CartEventDto,ShoppingCartViewModel>().ReverseMap();
            CreateMap<TeamDTO,Team>().ReverseMap();
            CreateMap<PlayerDto,Player>().ReverseMap();
            CreateMap<SateliteDto,Satelite>().ReverseMap();
            CreateMap<PlanetDto, Planet>().ReverseMap();
            
            CreateMap<ProductEventDTO, ProductDTO>().ReverseMap();

            CreateMap<CategoryDTO, Category>();

            CreateMap<ProductDTO, Product>();

            CreateMap<ReviewDTO, Review>();

            CreateMap<AttributeDTO, Attribute>();

            CreateMap<AttributeValueDTO, AttributeValue>();

            CreateMap<ProductAttributeDTO, ProductAttribute>();
        }
    }
}
