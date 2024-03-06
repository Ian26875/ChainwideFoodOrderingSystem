using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Command;

namespace ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.CreateOrder;

public interface ICreateOrderUseCase : ICommandHandler<CreateOrderInput,CqrsOutput<Guid>>
{
    
}