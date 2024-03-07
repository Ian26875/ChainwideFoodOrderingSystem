using ChainwideFoodOrderingSystem.Orders.Entity.DomainEvents;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.DomainEvents;

namespace ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.Policy.OrderCreated;

public class NotifyCustomer : IEventHandler<OrderCreatedEvent>
{
    
    public Task HandleAsync(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}