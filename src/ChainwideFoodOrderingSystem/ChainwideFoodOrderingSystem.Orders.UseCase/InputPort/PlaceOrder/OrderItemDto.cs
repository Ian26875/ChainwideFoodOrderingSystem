﻿namespace ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.PlaceOrder;

public class OrderItemDto
{
    /// <summary>
    /// 餐點唯一識別碼
    /// </summary>
    public int MenuItemId { get; set; }

    /// <summary>
    /// 餐點的名稱
    /// </summary>
    public string MenuItemName { get; set; }

    /// <summary>
    /// 訂購的數量
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// 餐點的單價
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// 餐點的描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 餐點的選項或變體，例如「不要洋蔥」或「加辣」
    /// </summary>
    public string Options { get; set; }
    
    /// <summary>
    /// 餐點的分類，如「主菜」、「甜點」、「飲料」等
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// 對這個餐點項目的特殊要求或備註
    /// </summary>
    public string SpecialInstructions { get; set; }
}