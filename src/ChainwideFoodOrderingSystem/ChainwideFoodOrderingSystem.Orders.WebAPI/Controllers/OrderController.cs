using Asp.Versioning;
using AutoMapper;
using ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.CreateOrder;
using ChainwideFoodOrderingSystem.Orders.WebAPI.Infrastructure.ActionFilters;
using ChainwideFoodOrderingSystem.Orders.WebAPI.Models.CreateOrder;
using Microsoft.AspNetCore.Mvc;

namespace ChainwideFoodOrderingSystem.Orders.WebAPI.Controllers;

/// <summary>
///     Represents a controller for handling orders.
/// </summary>
[ApiVersion("1")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class OrderController : ControllerBase
{
    private readonly ICreateOrderUseCase _createOrderUseCase;

    private readonly IMapper _mapper;

    /// <summary>
    ///     Represents a controller for handling orders.
    /// </summary>
    public OrderController(ICreateOrderUseCase createOrderUseCase,
        IMapper mapper)
    {
        _createOrderUseCase = createOrderUseCase;
        _mapper = mapper;
    }

    /// <summary>
    ///     Creates a new order.
    /// </summary>
    /// <param name="createOrderRequest">The request containing the details of the order to be created.</param>
    /// <returns>The result of the order creation.</returns>
    [HttpPost]
    [ValidateRequest(typeof(CreateOrderRequest))]
    public async Task<IActionResult> CreateAsync(CreateOrderRequest createOrderRequest)
    {
        var orderItems = _mapper.Map<List<OrderItemDto>>(createOrderRequest.OrderItems);

        var createOrderInput = new CreateOrderInput
        (
            createOrderRequest.BuyId,
            createOrderRequest.Address,
            orderItems
        );

        var output = await _createOrderUseCase.ExecuteAsync(createOrderInput);

        return Ok(CreateOrderResponse.Succeed(output.Id.ToString()));
    }
}