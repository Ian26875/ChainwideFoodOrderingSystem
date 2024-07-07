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
[ApiUniversalResponse]
public class OrderController : ControllerBase
{
    private readonly IPlaceOrderUseCase _placeOrderUseCase;

    private readonly IMapper _mapper;

    /// <summary>
    ///     Represents a controller for handling orders.
    /// </summary>
    public OrderController(IPlaceOrderUseCase placeOrderUseCase,
        IMapper mapper)
    {
        _placeOrderUseCase = placeOrderUseCase;
        _mapper = mapper;
    }

    /// <summary>
    ///     Creates a new order.
    /// </summary>
    /// <param name="placeOrderRequest">The request containing the details of the order to be created.</param>
    /// <returns>The result of the order creation.</returns>
    [HttpPost]
    [ValidateRequest(typeof(PlaceOrderRequest))]
    public async Task<IActionResult> PlaceOrderAsync(PlaceOrderRequest placeOrderRequest)
    {
        var orderItems = _mapper.Map<List<OrderItemDto>>(placeOrderRequest.OrderItems);

        var createOrderInput = new PlaceOrderInput
        (
            placeOrderRequest.BuyId,
            placeOrderRequest.Address,
            orderItems
        );

        var output = await _placeOrderUseCase.ExecuteAsync(createOrderInput);

        return Ok(PlaceOrderResponse.Succeed(output.Id.ToString()));
    }
}