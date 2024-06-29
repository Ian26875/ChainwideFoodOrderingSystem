namespace ChainwideFoodOrderingSystem.Orders.WebAPI.Models.CreateOrder;

public class CreateOrderResponse
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; }

    public string Code { get; set; }

    public string OrderId { get; set; }
}