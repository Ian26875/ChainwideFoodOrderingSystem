namespace ChainwideFoodOrderingSystem.SeedWork.DomainModel;

public interface IInternalEventHandler
{
    void Handle(IDomainEvent domainEvent);
}