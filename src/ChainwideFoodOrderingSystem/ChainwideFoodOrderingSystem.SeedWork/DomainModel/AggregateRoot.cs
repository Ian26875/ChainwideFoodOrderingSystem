namespace ChainwideFoodOrderingSystem.SeedWork.DomainModel;

/// <summary>
/// The aggregate root class
/// </summary>
/// <seealso cref="IInternalEventHandler"/>
public abstract class AggregateRoot<TId> : IInternalEventHandler where TId : ValueObject<TId>
{
    public TId Id { get; }
    
    /// <summary>
    /// The uncommitted changes
    /// </summary>
    private readonly List<DomainEvent> _uncommittedChanges = new();

    /// <summary>
    /// Handles the domain event
    /// </summary>
    /// <param name="domainEvent">The domain event</param>
    void IInternalEventHandler.Handle(DomainEvent domainEvent)
    {
        When(domainEvent);
    }

    /// <summary>
    /// Gets the uncommitted changes
    /// </summary>
    /// <returns>The uncommitted changes</returns>
    public IReadOnlyList<DomainEvent> GetUncommittedChanges()
    {
        return _uncommittedChanges;
    }

    /// <summary>
    /// Whens the domain event
    /// </summary>
    /// <param name="domainEvent">The domain event</param>
    protected abstract void When(DomainEvent domainEvent);

    /// <summary>
    /// Applies the domain event
    /// </summary>
    /// <param name="domainEvent">The domain event</param>
    protected void Apply(DomainEvent domainEvent)
    {
        When(domainEvent);
        EnsureValidState();
        _uncommittedChanges.Add(domainEvent);
    }

    /// <summary>
    /// Clears the uncommitted changes
    /// </summary>
    public void ClearUncommittedChanges()
    {
        _uncommittedChanges.Clear();
    }

    /// <summary>
    /// Loads the domain events
    /// </summary>
    /// <param name="domainEvents">The domain events</param>
    public void Load(IEnumerable<DomainEvent> domainEvents)
    {
        foreach (var domainEvent in domainEvents)
        {
            When(domainEvent);
        }
    }

    /// <summary>
    /// Ensures the valid state
    /// </summary>
    protected abstract void EnsureValidState();

    /// <summary>
    /// Applies the to entity using the specified entity
    /// </summary>
    /// <param name="entity">The entity</param>
    /// <param name="domainEvent">The domain event</param>
    protected void ApplyToEntity(IInternalEventHandler entity, DomainEvent domainEvent)
    {
        entity?.Handle(domainEvent);
    }
}