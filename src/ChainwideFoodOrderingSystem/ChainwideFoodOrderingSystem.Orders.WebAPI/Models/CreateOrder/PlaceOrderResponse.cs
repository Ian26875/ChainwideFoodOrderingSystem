using ChainwideFoodOrderingSystem.Orders.WebAPI.Infrastructure.ResultCodes;

namespace ChainwideFoodOrderingSystem.Orders.WebAPI.Models.CreateOrder;

public record PlaceOrderResponse(string OrderId,bool IsSuccess,string Code,string Message)
{
    public static PlaceOrderResponse Succeed(string orderId) => new PlaceOrderResponse
    (
        OrderId: orderId,
        IsSuccess: true,
        Code: ResultCodes.OrderCreated.Value,
        Message: ResultCodes.OrderCreated.Message
    );
    
    public static PlaceOrderResponse Fail(string errorCode, string errorMessage) => new PlaceOrderResponse
    (
        OrderId: null,
        IsSuccess: false,
        Code: errorCode,
        Message: errorMessage
    );
}