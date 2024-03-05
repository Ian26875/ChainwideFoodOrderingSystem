namespace ChainwideFoodOrderingSystem.SeedWork.DomainModel;

/// <summary>
/// The entity class
/// </summary>
/// <seealso cref="IInternalEventHandler"/>
public abstract class Entity<TId> : IInternalEventHandler where TId : ValueObject<TId>
{
    /// <summary>
    /// The applier
    /// </summary>
    private readonly Action<DomainEvent> _applier;

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class
    /// </summary>
    /// <param name="applier">The applier</param>
    protected Entity(Action<DomainEvent> applier)
    {
        _applier = applier;
    }

    /// <summary>
    /// Gets or sets the value of the id
    /// </summary>
    public TId Id { get; protected set; }

    /// <summary>
    /// Handles the domain event
    /// </summary>
    /// <param name="domainEvent">The domain event</param>
    void IInternalEventHandler.Handle(DomainEvent domainEvent)
    {
        When(domainEvent);
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
        _applier(domainEvent);
    }
}