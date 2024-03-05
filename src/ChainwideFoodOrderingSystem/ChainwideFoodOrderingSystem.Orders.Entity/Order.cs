using ChainwideFoodOrderingSystem.Orders.Entity.DomainEvents;
using ChainwideFoodOrderingSystem.SeedWork.DomainModel;

namespace ChainwideFoodOrderingSystem.Orders.Entity;

public class Order : AggregateRoot<OrderId>
{
    public List<OrderItem> OrderItems { get; }

    public BuyId BuyId { get; }

    public Address Address { get; }

    /// <summary>
    /// 訂單狀態
    /// </summary>
    public OrderStatus Status { get; private set; }

    public DateTime CreatedAt { get; }

    /// <summary>
    ///     取得訂單的總價。
    /// </summary>
    /// <returns>訂單的總價。</returns>
    public decimal GetTotalAmount()
    {
        return OrderItems.Sum(o => o.Quantity * o.UnitPrice);
    }


    public void AddOrderItem(int menuItemId,string menuItemName)
    {
        
    }
    
    /// <summary>
    ///     將訂單標記為已接受。
    /// </summary>
    public void MarkAsAccepted()
    {
        if (Status != OrderStatus.Pending)
        {
            throw new InvalidOperationException("訂單狀態不是處於待處理，無法接受訂單。");
        }

        Status = OrderStatus.Accepted;

        Apply(new OrderMarkedAsAcceptedEvent(Id));
    }


    protected override void When(DomainEvent domainEvent)
    {
    }

    protected override void EnsureValidState()
    {
    }
}