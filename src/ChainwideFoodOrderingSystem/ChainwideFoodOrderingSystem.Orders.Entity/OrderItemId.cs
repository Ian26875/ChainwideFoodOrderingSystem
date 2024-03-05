using ChainwideFoodOrderingSystem.SeedWork.DomainModel;

namespace ChainwideFoodOrderingSystem.Orders.Entity;

public class OrderItemId  : ValueObject<OrderItemId>
{
    public Guid Value { get; }

    private OrderItemId(Guid value)
    {
        this.Value = value;
    }

    public static implicit operator Guid(OrderItemId orderId) => orderId.Value;

    public static implicit operator OrderItemId(Guid value) => new OrderItemId(value);

    public override string ToString() => this.Value.ToString();
}