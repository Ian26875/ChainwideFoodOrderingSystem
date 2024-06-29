using Asp.Versioning;
using ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.CreateOrder;
using ChainwideFoodOrderingSystem.Orders.WebAPI.Infrastructure.ResultCodes;
using ChainwideFoodOrderingSystem.Orders.WebAPI.Models.CreateOrder;
using Microsoft.AspNetCore.Mvc;

namespace ChainwideFoodOrderingSystem.Orders.WebAPI.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class OrderController : ControllerBase
{
    private readonly ICreateOrderUseCase _createOrderUseCase;

    public OrderController(ICreateOrderUseCase createOrderUseCase)
    {
        _createOrderUseCase = createOrderUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateOrderRequest createOrderRequest)
    {
        var orderItemInputs = createOrderRequest.OrderItems;
        
        var createOrderInput = new CreateOrderInput
        (
            createOrderRequest.BuyId, 
            createOrderRequest.Address,
            new List<OrderItemDto>()
        );

        var output = await this._createOrderUseCase.ExecuteAsync(createOrderInput);
        if (output.ExitCode.IsSuccess())
        {
            var createOrderResponse = new CreateOrderResponse
            {
                IsSuccess = true,
                OrderId = output.Id.ToString(),
                Code = ResultCodes.OrderCreated.Value,
                Message = ResultCodes.OrderCreated.Message
            };
            return Ok(createOrderResponse);
        }
        
        return Ok();
    }
}