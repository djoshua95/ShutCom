using Microsoft.Extensions.DependencyInjection;
using MysticMadness.Service.Factories;
using MysticMadness.Service.Services;
using MysticMadness.Domain.Repository;
using MysticMadness.Domain.UnitOfWorkPattern;

namespace MysticMadness.Service;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IPagedResultFactory, PagedResultFactory>();
        services.AddTransient<IOrderService, OrderService>();
        return services;
    }
}