using ChainwideFoodOrderingSystem.SeedWork.DomainModel;

namespace ChainwideFoodOrderingSystem.Orders.Entity.DomainEvents;

/// <summary>
/// 餐廳已拒絕接收訂單
/// </summary>
public class OrderMarkedAsRejectedEvent : DomainEvent
{
    public Guid OrderId { get; }

    public OrderMarkedAsRejectedEvent(OrderId orderId)
    {
        this.OrderId = orderId;
    }
}