using AutoMapper;
using MysticMadness.Dto;
using MysticMadness.Model.Entities;

namespace MysticMadness.Service.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Product, ProductDto>()
            .ForMember(p => p.Stock, dto => dto.MapFrom(x => x.Stock > 0 ))
            .ReverseMap();
    }
}