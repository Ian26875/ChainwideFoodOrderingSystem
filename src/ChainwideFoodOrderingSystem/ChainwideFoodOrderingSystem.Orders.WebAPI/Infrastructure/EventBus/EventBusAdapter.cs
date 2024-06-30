using ChainwideFoodOrderingSystem.SeedWork.Entity;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.DomainEvents;

namespace ChainwideFoodOrderingSystem.Orders.WebAPI.Infrastructure.EventBus;

public class EventBusAdapter : IEventBus
{
    public async Task PublishAsync<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : DomainEvent
    {
        
    }
}