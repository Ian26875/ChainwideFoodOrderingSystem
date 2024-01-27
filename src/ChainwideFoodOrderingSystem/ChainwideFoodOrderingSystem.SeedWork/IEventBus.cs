namespace ChainwideFoodOrderingSystem.SeedWork;

public interface IEventBus
{
    Task PublishAsync(IDomainEvent domainEvent);
}