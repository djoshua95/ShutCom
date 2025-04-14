using AutoMapper;
using MysticMadness.Dto;
using MysticMadness.Model.Entities;

namespace MysticMadness.Service.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, OrderDto>().ReverseMap();
    }
}