using ChainwideFoodOrderingSystem.SeedWork.Entity;

namespace ChainwideFoodOrderingSystem.Orders.Entity;

public class OrderId : ValueObject<OrderId>
{
    public Guid Value { get; }

    private OrderId(Guid value)
    {
        this.Value = value;
    }

    public static implicit operator Guid(OrderId orderId) => orderId.Value;

    public static implicit operator OrderId(Guid value) => new OrderId(value);

    public override string ToString() => this.Value.ToString();
   
}

