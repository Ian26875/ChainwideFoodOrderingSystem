using ChainwideFoodOrderingSystem.SeedWork.Entity;

namespace ChainwideFoodOrderingSystem.Orders.Entity.DomainEvents;

public class OrderCancelledEvent : DomainEvent
{
    public Guid OrderId { get; }

    public OrderCancelledEvent(Guid orderId)
    {
        OrderId = orderId;
    }
}