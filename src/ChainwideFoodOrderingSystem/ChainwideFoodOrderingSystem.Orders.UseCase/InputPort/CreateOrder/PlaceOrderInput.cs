using System.ComponentModel.DataAnnotations;
using ChainwideFoodOrderingSystem.SeedWork.UseCase;

namespace ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.CreateOrder;

/// <summary>
///     The create order input class
/// </summary>
/// <seealso cref="Input" />
public class PlaceOrderInput : Input
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PlaceOrderInput" /> class
    /// </summary>
    /// <param name="buyId">The buy id</param>
    /// <param name="address">The address</param>
    /// <param name="orderItems">The order items</param>
    public PlaceOrderInput(int buyId, string address, List<OrderItemDto> orderItems)
    {
        BuyId = buyId;
        Address = address;
        OrderItems = orderItems;
        this.ValidateSelf();
    }

    /// <summary>
    ///     Gets the value of the buy id
    /// </summary>
    [Range(0, int.MaxValue)]
    public int BuyId { get; }

    /// <summary>
    ///     Gets the value of the address
    /// </summary>
    [StringLength(100)]
    public string Address { get; }

    /// <summary>
    ///     Gets the value of the order items
    /// </summary>
    public List<OrderItemDto> OrderItems { get; }
}