using ChainwideFoodOrderingSystem.SeedWork.Entity;

namespace ChainwideFoodOrderingSystem.Orders.Entity.DomainEvents;

public class OrderCreatedEvent : DomainEvent
{

    public Guid OrderId { get; }

    public int BuyId { get; }


    public string Address { get; }

    public OrderCreatedEvent( Guid orderId, int buyId,string address)
    {
        OrderId = orderId;
        BuyId = buyId;
        Address = address;
    }
}