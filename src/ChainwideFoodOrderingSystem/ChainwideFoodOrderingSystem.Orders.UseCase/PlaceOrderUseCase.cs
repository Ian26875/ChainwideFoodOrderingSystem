using ChainwideFoodOrderingSystem.Orders.Entity;
using ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.CreateOrder;
using ChainwideFoodOrderingSystem.Orders.UseCase.OutputPort;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.DomainEvents;

namespace ChainwideFoodOrderingSystem.Orders.UseCase;

/// <summary>
/// Use case for creating a new order.
/// </summary>
public class PlaceOrderUseCase : IPlaceOrderUseCase
{
    /// <summary>
    /// The order repository
    /// </summary>
    private readonly IOrderRepository _orderRepository;

    /// <summary>
    /// The event bus
    /// </summary>
    private readonly IEventBus _eventBus;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="PlaceOrderUseCase"/> class
    /// </summary>
    /// <param name="orderRepository">The order repository</param>
    /// <param name="eventBus">The event bus</param>
    public PlaceOrderUseCase(IOrderRepository orderRepository, IEventBus eventBus)
    {
        _orderRepository = orderRepository;
        _eventBus = eventBus;
    }

    /// <summary>
    /// Executes the CreateOrderUseCase asynchronously.
    /// </summary>
    /// <param name="input">The input for creating a new order.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the CreateOrderUseCase execution.</returns>
    public async Task<CqrsOutput<Guid>> ExecuteAsync(PlaceOrderInput input,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(input);

        var order = Order.Create
        (
            Guid.NewGuid(),
            input.BuyId,
            Address.FromString(input.Address)
        );

        foreach (var orderItem in input.OrderItems)
        {
            order.AddOrderItem
            (
                orderItem.MenuItemId,
                orderItem.MenuItemName,
                orderItem.Quantity,
                orderItem.UnitPrice,
                orderItem.Description,
                orderItem.Options,
                orderItem.Category,
                orderItem.SpecialInstructions
            );
        }
        
        var orderCreated = await this._orderRepository.SaveAsync(order);

        await this._eventBus.DispatchDomainEventAsync(order);
        
        return CqrsOutput<Guid>.Succeed()
                               .WithId(orderCreated.Id);
    }
}