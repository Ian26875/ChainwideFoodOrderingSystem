namespace ChainwideFoodOrderingSystem.SeedWork;

public abstract class AggregateRoot : IInternalEventHandler
{
    private readonly List<IDomainEvent> _uncommittedChanges = new();

    void IInternalEventHandler.Handle(IDomainEvent domainEvent)
    {
        When(domainEvent);
    }

    public IReadOnlyList<IDomainEvent> GetUncommittedChanges()
    {
        return _uncommittedChanges;
    }

    protected abstract void When(IDomainEvent domainEvent);

    protected void Apply(IDomainEvent domainEvent)
    {
        When(domainEvent);
        EnsureValidState();
        _uncommittedChanges.Add(domainEvent);
    }

    public void ClearUncommittedChanges()
    {
        _uncommittedChanges.Clear();
    }

    public void Load(IEnumerable<IDomainEvent> domainEvents)
    {
        foreach (var domainEvent in domainEvents) When(domainEvent);
    }

    protected abstract void EnsureValidState();

    protected void ApplyToEntity(IInternalEventHandler entity, IDomainEvent domainEvent)
    {
        entity?.Handle(domainEvent);
    }
}