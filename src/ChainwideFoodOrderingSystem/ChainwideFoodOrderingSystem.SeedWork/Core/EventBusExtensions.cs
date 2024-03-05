using ChainwideFoodOrderingSystem.SeedWork.DomainModel;

namespace ChainwideFoodOrderingSystem.SeedWork.Core;

public static class EventBusExtensions
{
    public static async Task DispatchDomainEventAsync<TId>(this IEventBus eventBus, AggregateRoot<TId> aggregateRoot) where TId : ValueObject<TId>
    {
        foreach (var domainEvent in aggregateRoot.GetUncommittedChanges())
        {
            await eventBus.PublishAsync(domainEvent);
        }
        
        aggregateRoot.ClearUncommittedChanges();
    }
}