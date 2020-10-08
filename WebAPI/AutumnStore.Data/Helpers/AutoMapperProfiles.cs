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
            CreateMap<User, UserForRegisterDto>();
            CreateMap<User, UserForLoginDto>();
            CreateMap<User, UserForEmailDto>();

            CreateMap<OrderDto, Order>()
                .ForMember(dest => dest.OrderProduct, opt => opt.MapFrom(src => src.OrderedProductsDto));

            CreateMap<OrderedProductsDto, OrderProduct>()
                .ForMember(dest => dest.ProductQty, opt => opt.MapFrom(src => src.Qty))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Price));

            CreateMap<OrderedProductsDto, OrderProduct>()
                .ForMember(dest => dest.ProductQty, opt => opt.MapFrom(src => src.Qty))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Price)).ReverseMap();
        }
    }
}
