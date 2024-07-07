using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Command;

namespace ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.CreateOrder;

public interface IPlaceOrderUseCase : ICommandHandler<CreateOrderInput,CqrsOutput<Guid>>
{
    
}