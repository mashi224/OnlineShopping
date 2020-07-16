using AutoMapper;
using OnlineShopping.API.Dtos;
using OnlineShopping.API.Models;

namespace OnlineShopping.API.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Products, ProductDto>();
            CreateMap<Category, CategoryDto>();
            // CreateMap<Products, ProductRetrieveDto>();
        }
    }
}