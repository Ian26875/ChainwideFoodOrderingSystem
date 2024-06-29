using ChainwideFoodOrderingSystem.Orders.WebAPI.Infrastructure.ResultCodes;

namespace ChainwideFoodOrderingSystem.Orders.WebAPI.Models.CreateOrder;

public record CreateOrderResponse(string OrderId,bool IsSuccess,string Code,string Message)
{
    public static CreateOrderResponse Succeed(string orderId) => new CreateOrderResponse
    (
        OrderId: orderId,
        IsSuccess: true,
        Code: ResultCodes.OrderCreated.Value,
        Message: ResultCodes.OrderCreated.Message
    );
    
    public static CreateOrderResponse Fail(string errorCode, string errorMessage) => new CreateOrderResponse
    (
        OrderId: null,
        IsSuccess: false,
        Code: errorCode,
        Message: errorMessage
    );
}