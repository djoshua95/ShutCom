using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace MysticMadness.Service.Mapping;

public static class MappingExtension
{
    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(m =>
        {
            m.AddProfile(new MappingProfile());
        });
        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
        return services;
    }
}
