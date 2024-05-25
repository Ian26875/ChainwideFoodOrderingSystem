using ChainwideFoodOrderingSystem.Orders.Entity;

namespace ChainwideFoodOrderingSystem.Orders.UseCase.Errors;

public class OrderNotFoundException : Exception
{
    /// <summary>
    /// 初始化 OrderNotFoundException 類的新實例。
    /// </summary>
    /// <param name="orderId">未找到的訂單ID。</param>
    public OrderNotFoundException(OrderId orderId) 
        : base($"Order with ID {orderId} not found.")
    {
        this.OrderId = orderId;
    }

    /// <summary>
    /// 獲取未找到的訂單ID。
    /// </summary>
    public OrderId OrderId { get; }

    /// <summary>
    /// 如果指定的訂單為空，則拋出 OrderNotFoundException。
    /// </summary>
    /// <param name="order">要檢查的訂單。</param>
    /// <param name="orderId">訂單ID，用於當訂單為空時提供錯誤訊息。</param>
    /// <exception cref="OrderNotFoundException">當訂單為空時拋出。</exception>
    public static void ThrowIfOrderNotFound(Order? order, OrderId orderId)
    {
        if (order is null)
        {
            throw new OrderNotFoundException(orderId);
        }
    }
}
