using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Command;

namespace ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.PlaceOrder;

public interface IPlaceOrderUseCase : ICommandHandler<PlaceOrderInput,CqrsOutput<Guid>>
{
    
}