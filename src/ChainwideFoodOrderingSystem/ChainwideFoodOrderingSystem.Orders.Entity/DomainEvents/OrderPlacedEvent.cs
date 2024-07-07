using ChainwideFoodOrderingSystem.SeedWork.Entity;

namespace ChainwideFoodOrderingSystem.Orders.Entity.DomainEvents;

public class OrderPlacedEvent : DomainEvent
{
    public OrderPlacedEvent(Guid orderId, int buyId, string address)
    {
        OrderId = orderId;
        BuyId = buyId;
        Address = address;
    }

    public Guid OrderId { get; }

    public int BuyId { get; }
    
    public string Address { get; }
}