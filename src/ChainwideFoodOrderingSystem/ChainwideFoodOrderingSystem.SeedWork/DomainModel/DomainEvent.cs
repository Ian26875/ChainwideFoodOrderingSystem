namespace ChainwideFoodOrderingSystem.SeedWork.DomainModel;

/// <summary>
/// The domain event class
/// </summary>
/// <seealso cref="ValueObject{DomainEvent}"/>
public class DomainEvent : ValueObject<DomainEvent>
{
    /// <summary>
    /// Gets the value of the event id
    /// </summary>
    public Guid EventId { get; }

    /// <summary>
    /// Gets the value of the created at
    /// </summary>
    public DateTime CreatedAt { get; }
    
    
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainEvent"/> class
    /// </summary>
    /// <param name="eventId">The event id</param>
    /// <param name="createdAt">The created at</param>
    public DomainEvent(Guid eventId, DateTime createdAt)
    {
        EventId = eventId;
        CreatedAt = createdAt;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainEvent"/> class
    /// </summary>
    public DomainEvent() : this(Guid.NewGuid(), DateTime.UtcNow)
    {
        
    }
}