namespace ChainwideFoodOrderingSystem.SeedWork;

public interface IInternalEventHandler
{
    void Handle(IDomainEvent domainEvent);
}