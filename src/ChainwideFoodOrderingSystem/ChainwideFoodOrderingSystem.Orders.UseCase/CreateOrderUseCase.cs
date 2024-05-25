using ChainwideFoodOrderingSystem.Orders.Entity;
using ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.CreateOrder;
using ChainwideFoodOrderingSystem.Orders.UseCase.OutputPort;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.DomainEvents;

namespace ChainwideFoodOrderingSystem.Orders.UseCase;

/// <summary>
/// The create order use case class
/// </summary>
/// <seealso cref="ICreateOrderUseCase"/>
public class CreateOrderUseCase : ICreateOrderUseCase
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
    /// Initializes a new instance of the <see cref="CreateOrderUseCase"/> class
    /// </summary>
    /// <param name="orderRepository">The order repository</param>
    /// <param name="eventBus">The event bus</param>
    public CreateOrderUseCase(IOrderRepository orderRepository, IEventBus eventBus)
    {
        _orderRepository = orderRepository;
        _eventBus = eventBus;
    }

    /// <summary>
    /// Executes the input
    /// </summary>
    /// <param name="input">The input</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>A task containing a cqrs output of guid</returns>
    public async Task<CqrsOutput<Guid>> ExecuteAsync(CreateOrderInput input, CancellationToken cancellationToken = default)
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