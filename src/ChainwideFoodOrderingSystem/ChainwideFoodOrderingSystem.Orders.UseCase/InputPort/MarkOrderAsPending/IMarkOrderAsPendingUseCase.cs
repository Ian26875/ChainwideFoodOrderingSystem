using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Command;

namespace ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.MarkOrderAsPending;

/// <summary>
/// 將訂單標記為待處理狀態 UseCase Interface。
/// </summary>
public interface IMarkOrderAsPendingUseCase : ICommandHandler<MarkOrderAsPendingInput, CqrsOutput>
{
    
}
