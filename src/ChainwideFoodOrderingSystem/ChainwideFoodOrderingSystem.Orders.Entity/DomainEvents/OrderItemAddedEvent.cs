using ChainwideFoodOrderingSystem.SeedWork.Entity;

namespace ChainwideFoodOrderingSystem.Orders.Entity.DomainEvents;

/// <summary>
/// The order item added event class
/// </summary>
/// <seealso cref="DomainEvent"/>
public class OrderItemAddedEvent : DomainEvent
{
    /// <summary>
    ///     餐點唯一識別碼
    /// </summary>
    public int MenuItemId { get; }

    /// <summary>
    ///     餐點的名稱
    /// </summary>
    public string MenuItemName { get; }

    /// <summary>
    ///     訂購的數量
    /// </summary>
    public int Quantity { get; }

    /// <summary>
    ///     餐點的單價
    /// </summary>
    public decimal UnitPrice { get; }

    /// <summary>
    ///     餐點的描述
    /// </summary>
    public string Description { get; }

    /// <summary>
    ///     餐點的選項或變體，例如「不要洋蔥」或「加辣」
    /// </summary>
    public string Options { get; }

    /// <summary>
    ///     餐點的分類，如「主菜」、「甜點」、「飲料」等
    /// </summary>
    public string Category { get; }

    /// <summary>
    ///     對這個餐點項目的特殊要求或備註
    /// </summary>
    public string SpecialInstructions { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderItemAddedEvent"/> class
    /// </summary>
    /// <param name="menuItemId">The menu item id</param>
    /// <param name="menuItemName">The menu item name</param>
    /// <param name="quantity">The quantity</param>
    /// <param name="unitPrice">The unit price</param>
    /// <param name="description">The description</param>
    /// <param name="options">The options</param>
    /// <param name="category">The category</param>
    /// <param name="specialInstructions">The special instructions</param>
    public OrderItemAddedEvent(int menuItemId, 
                               string menuItemName, 
                               int quantity, 
                               decimal unitPrice, 
                               string description, 
                               string options, 
                               string category, 
                               string specialInstructions)
    {
        MenuItemId = menuItemId;
        MenuItemName = menuItemName;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Description = description;
        Options = options;
        Category = category;
        SpecialInstructions = specialInstructions;
    }
}