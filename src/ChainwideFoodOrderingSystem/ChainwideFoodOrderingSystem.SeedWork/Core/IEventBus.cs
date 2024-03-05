using ChainwideFoodOrderingSystem.SeedWork.DomainModel;

namespace ChainwideFoodOrderingSystem.SeedWork.Core;

public interface IEventBus
{
    Task PublishAsync(DomainEvent domainEvent);
}