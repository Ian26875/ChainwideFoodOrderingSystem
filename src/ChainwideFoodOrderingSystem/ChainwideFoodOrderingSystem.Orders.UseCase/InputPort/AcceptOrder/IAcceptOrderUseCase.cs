using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Command;

namespace ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.AcceptOrder;

public interface IAcceptOrderUseCase : ICommandHandler<AcceptOrderInput, CqrsOutput>
{
}