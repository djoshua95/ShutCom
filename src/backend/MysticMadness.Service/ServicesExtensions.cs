using Microsoft.Extensions.DependencyInjection;
using MysticMadness.Service.Services;

namespace MysticMadness.Service;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IOrderService, OrderService>();
        return services;
    }
}