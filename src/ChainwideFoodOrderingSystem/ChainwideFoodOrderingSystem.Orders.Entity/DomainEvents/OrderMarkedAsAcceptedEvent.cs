using ChainwideFoodOrderingSystem.SeedWork.Entity;

namespace ChainwideFoodOrderingSystem.Orders.Entity.DomainEvents;

/// <summary>
/// 餐廳已接收訂單
/// </summary>
public class OrderMarkedAsAcceptedEvent : DomainEvent
{
    public Guid OrderId { get; }

    public OrderMarkedAsAcceptedEvent(OrderId orderId)
    {
        this.OrderId = orderId;
    }
}