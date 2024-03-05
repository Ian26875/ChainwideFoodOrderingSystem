using ChainwideFoodOrderingSystem.SeedWork.DomainModel;

namespace ChainwideFoodOrderingSystem.Orders.Entity;

/// <summary>
/// 訂單中的一個餐點項目。
/// </summary>
public class OrderItem : Entity<OrderItemId>
{
    /// <summary>
    /// 餐點唯一識別碼
    /// </summary>
    public int MenuItemId { get; }

    /// <summary>
    /// 餐點的名稱
    /// </summary>
    public string MenuItemName { get; }

    /// <summary>
    /// 訂購的數量
    /// </summary>
    public int Quantity { get; }

    /// <summary>
    /// 餐點的單價
    /// </summary>
    public decimal UnitPrice { get; }

    /// <summary>
    /// 餐點的描述
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// 餐點的選項或變體，例如「不要洋蔥」或「加辣」
    /// </summary>
    public string Options { get; }

    /// <summary>
    /// 餐點圖片的 URL
    /// </summary>
    public string ImageUrl { get; }

    /// <summary>
    /// 餐點的分類，如「主菜」、「甜點」、「飲料」等
    /// </summary>
    public string Category { get; }

    /// <summary>
    /// 對這個餐點項目的特殊要求或備註
    /// </summary>
    public string SpecialInstructions { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderItem"/> class
    /// </summary>
    /// <param name="applier">The applier</param>
    internal OrderItem(Action<DomainEvent> applier) : base(applier)
    {
    }

    /// <summary>
    /// Whens the domain event
    /// </summary>
    /// <param name="domainEvent">The domain event</param>
    protected override void When(DomainEvent domainEvent)
    {
        
    }
}