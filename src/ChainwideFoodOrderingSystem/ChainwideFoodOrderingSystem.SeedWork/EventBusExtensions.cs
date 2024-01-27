namespace ChainwideFoodOrderingSystem.SeedWork;

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