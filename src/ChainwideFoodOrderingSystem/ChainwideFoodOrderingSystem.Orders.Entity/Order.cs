using ChainwideFoodOrderingSystem.Orders.Entity.DomainEvents;
using ChainwideFoodOrderingSystem.SeedWork.Entity;

namespace ChainwideFoodOrderingSystem.Orders.Entity;

/// <summary>
///     訂單聚合根
/// </summary>
public class Order : AggregateRoot<OrderId>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Order" /> class
    /// </summary>
    private Order()
    {
    }

    /// <summary>
    ///     訂單項目列表
    /// </summary>
    public List<OrderItem> OrderItems { get; }

    /// <summary>
    ///     購買者識別碼
    /// </summary>
    public BuyId BuyId { get; private set; }

    /// <summary>
    ///     配送地址
    /// </summary>
    public Address Address { get; private set; }

    /// <summary>
    ///     訂單狀態
    /// </summary>
    public OrderStatus Status { get; private set; }

    /// <summary>
    ///     訂單創建時間
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    ///     取得訂單的總價。
    /// </summary>
    /// <returns>訂單的總價。</returns>
    public decimal GetTotalAmount()
    {
        return OrderItems.Sum(o => o.Quantity * o.UnitPrice);
    }

    /// <summary>
    ///     Creates the buy id
    /// </summary>
    /// <param name="buyId">The buy id</param>
    /// <param name="address">The address</param>
    /// <returns>The order</returns>
    public static Order Create(BuyId buyId, Address address)
    {
        var order = new Order();
        order.Apply(new OrderCreatedEvent(buyId, address));
        return order;
    }

    /// <summary>
    /// 添加訂單項目
    /// </summary>
    /// <param name="menuItemId"></param>
    /// <param name="menuItemName"></param>
    /// <param name="quantity"></param>
    /// <param name="unitPrice"></param>
    /// <param name="description"></param>
    /// <param name="options"></param>
    /// <param name="category"></param>
    /// <param name="specialInstructions"></param>
    public void AddOrderItem(int menuItemId,
                             string menuItemName,
                             int quantity,
                             decimal unitPrice,
                             string description,
                             string options,
                             string category,
                             string specialInstructions)
    {
        var orderItemAddedEvent = new OrderItemAddedEvent
        (
            menuItemId,
            menuItemName,
            quantity,
            unitPrice,
            description,
            options,
            category,
            specialInstructions
        );
        Apply(orderItemAddedEvent);
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
        
        Apply(new OrderMarkedAsAcceptedEvent(Id));
    }

    /// <summary>
    ///     Whens the domain event
    /// </summary>
    /// <param name="domainEvent">The domain event</param>
    protected override void When(DomainEvent domainEvent)
    {

        switch (domainEvent)
        {
            case OrderCreatedEvent orderCreatedEvent:
                BuyId = orderCreatedEvent.BuyId;
                Address = Address.FromString(orderCreatedEvent.Address);
                Status = OrderStatus.Draft;
                CreatedAt = DateTime.UtcNow;
                break;
            
            case OrderItemAddedEvent orderItemAddedEvent:
                var existingOrderForMenu = this.OrderItems.SingleOrDefault(o => o.MenuItemId == orderItemAddedEvent.MenuItemId);
                if (existingOrderForMenu != null)
                {
                    this.OrderItems.Remove(existingOrderForMenu);
                }
                var orderItem = new OrderItem(Apply);
                ApplyToEntity(orderItem,orderItemAddedEvent);
                OrderItems.Add(orderItem);
                break;
            
            case OrderMarkedAsAcceptedEvent orderMarkedAsAcceptedEvent:
                Status = OrderStatus.Accepted;
                break;
            
        }
    }

    /// <summary>
    ///     Ensures the valid state
    /// </summary>
    protected override void EnsureValidState()
    {
    }
}