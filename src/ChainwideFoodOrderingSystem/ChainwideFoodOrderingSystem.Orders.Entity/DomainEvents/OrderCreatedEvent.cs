using ChainwideFoodOrderingSystem.SeedWork.Entity;

namespace ChainwideFoodOrderingSystem.Orders.Entity.DomainEvents;

public class OrderCreatedEvent : DomainEvent
{

    public int BuyId { get; }


    public string Address { get; }

    public OrderCreatedEvent( int buyId,string address)
    {
        BuyId = buyId;
        Address = address;
    }
}