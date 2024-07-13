using ChainwideFoodOrderingSystem.Orders.UseCase.Errors;
using ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.AcceptOrder;
using ChainwideFoodOrderingSystem.Orders.UseCase.OutputPort;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.DomainEvents;

namespace ChainwideFoodOrderingSystem.Orders.UseCase;

public class AcceptOrderUseCase : IAcceptOrderUseCase
{
    private readonly IOrderRepository _orderRepository;

    private readonly IEventBus _eventBus;
    
    public AcceptOrderUseCase(IOrderRepository orderRepository, IEventBus eventBus)
    {
        _orderRepository = orderRepository;
        _eventBus = eventBus;
    }

    public async Task<CqrsOutput> ExecuteAsync(AcceptOrderInput input, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(input);

        var order = await this._orderRepository.FindAsync(input.OrderId);
        if (order is null)
        {
            throw new OrderNotFoundException(input.OrderId);
        }

        order.MarkAsAccepted();

        await this._orderRepository.ModifyAsync(order);

        await this._eventBus.DispatchDomainEventAsync(order);
        
        
        return CqrsOutput.Succeed();
    }
}