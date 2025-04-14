using Microsoft.Extensions.DependencyInjection;
using MysticMadness.Service.Services;
using MysticMadness.Domain.Repository;
using MysticMadness.Domain.UnitOfWorkPattern;

namespace MysticMadness.Service;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IOrderService, OrderService>();
        return services;
    }
}