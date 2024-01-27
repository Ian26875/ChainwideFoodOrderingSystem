namespace ChainwideFoodOrderingSystem.SeedWork.DomainModel;

public abstract class Entity<TId> : IInternalEventHandler where TId : ValueObject<TId>
{
    private readonly Action<IDomainEvent> _applier;

    protected Entity(Action<IDomainEvent> applier)
    {
        _applier = applier;
    }

    public TId Id { get; protected set; }

    void IInternalEventHandler.Handle(IDomainEvent domainEvent)
    {
        When(domainEvent);
    }

    protected abstract void When(IDomainEvent domainEvent);

    protected void Apply(IDomainEvent domainEvent)
    {
        When(domainEvent);
        _applier(domainEvent);
    }
}