using ChainwideFoodOrderingSystem.SeedWork.DomainModel;

namespace ChainwideFoodOrderingSystem.SeedWork;

public interface IEventBus
{
    Task PublishAsync(IDomainEvent domainEvent);
}