using ChainwideFoodOrderingSystem.SeedWork.DomainModel;

namespace ChainwideFoodOrderingSystem.Orders.Entity.DomainEvents;

public class OrderCreatedEvent : DomainEvent
{
    public Guid OrderId { get; }
    
    public decimal TotalAmount { get; }

    
    
}