namespace ChainwideFoodOrderingSystem.SeedWork.DomainModel;

/// <summary>
/// The internal event handler interface
/// </summary>
public interface IInternalEventHandler
{
    /// <summary>
    /// Handles the domain event
    /// </summary>
    /// <param name="domainEvent">The domain event</param>
    void Handle(DomainEvent domainEvent);
}