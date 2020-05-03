using AutoMapper;
using Domain;

namespace Application.Products
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Image, ImageDTO>();
        }
    }
}