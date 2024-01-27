using ChainwideFoodOrderingSystem.SeedWork.DomainModel;

namespace ChainwideFoodOrderingSystem.SeedWork.Core;

public static class EventBusExtensions
{
    public static async Task DispatchDomainEventAsync(this IEventBus eventBus, AggregateRoot aggregateRoot)
    {
        foreach (var domainEvent in aggregateRoot.GetUncommittedChanges())
        {
            await eventBus.PublishAsync(domainEvent);
        }
        
        aggregateRoot.ClearUncommittedChanges();
    }
}