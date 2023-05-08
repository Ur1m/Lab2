using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyClone.DTO;
using UdemyClone.Models;
using Attribute = UdemyClone.Models.Attribute;

namespace UdemyClone.AutoMapper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CategoryDTO, Category>();
            CreateMap<ProductDTO, Product>();
            CreateMap<ReviewDTO, Review>();
            CreateMap<AttributeDTO, Attribute>();
            CreateMap<AttributeValueDTO, AttributeValue>();
            CreateMap<ProductAttributeDTO, ProductAttribute>();
        }
    }
}
