using AutoMapper;
using AutumnStore.Data.Model;
using AutumnStore.Entity;

namespace AutumnStore.Data.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Products, ProductDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<User, UserForRegisterDto>().ReverseMap();
            CreateMap<User, UserForLoginDto>();
        }
    }
}
