using ChainwideFoodOrderingSystem.Orders.Persistence;
using ChainwideFoodOrderingSystem.Orders.Persistence.Repositories;
using ChainwideFoodOrderingSystem.Orders.UseCase;
using ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.CreateOrder;
using ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.MarkOrderAsPending;
using ChainwideFoodOrderingSystem.Orders.UseCase.OutputPort;
using ChainwideFoodOrderingSystem.Orders.WebAPI.Infrastructure.EventBus;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.DomainEvents;
using Microsoft.EntityFrameworkCore;

namespace ChainwideFoodOrderingSystem.Orders.WebAPI.Infrastructure.DependencyInjection;

public static class DependencyInjectionContainer
{
    public static IServiceCollection AddEventBusModule(this IServiceCollection services)
    {
        return services.AddSingleton<IEventBus, EventBusAdapter>();
    }


    public static IServiceCollection AddOrderUseCaseModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPlaceOrderUseCase, PlaceOrderUseCase>();
        services.AddScoped<IMarkOrderAsPendingUseCase, MarkOrderAsPendingUseCase>();


        return services;
    }

    public static IServiceCollection AddOrderPersistenceModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();



        services.AddDbContext<FoodOrderingDbContext>((provider, builder) =>
        {
            builder.UseSqlServer
            (
                configuration.GetConnectionString("FoodOrdering")
            );
        });
        return services;
    }

}