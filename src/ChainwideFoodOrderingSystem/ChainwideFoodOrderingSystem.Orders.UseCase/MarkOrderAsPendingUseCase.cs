using ChainwideFoodOrderingSystem.Orders.UseCase.Errors;
using ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.MarkOrderAsPending;
using ChainwideFoodOrderingSystem.Orders.UseCase.OutputPort;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.DomainEvents;

namespace ChainwideFoodOrderingSystem.Orders.UseCase;

/// <summary>
/// 表示一個將訂單標記為待處理狀態的使用案例。
/// </summary>
public class MarkOrderAsPendingUseCase : IMarkOrderAsPendingUseCase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEventBus _eventBus;

    /// <summary>
    /// 初始化 MarkOrderAsPendingUseCase 類的新實例。
    /// </summary>
    /// <param name="orderRepository">訂單倉儲。</param>
    /// <param name="eventBus">事件匯流排。</param>
    public MarkOrderAsPendingUseCase(IOrderRepository orderRepository, IEventBus eventBus)
    {
        _orderRepository = orderRepository;
        _eventBus = eventBus;
    }

    /// <summary>
    /// 執行將訂單標記為待處理狀態的操作。
    /// </summary>
    /// <param name="input">輸入參數。</param>
    /// <param name="cancellationToken">取消權杖。</param>
    /// <returns>執行結果。</returns>
    public async Task<CqrsOutput> ExecuteAsync(MarkOrderAsPendingInput input, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(input);

        var orderToUpdate = await _orderRepository.FindAsync(input.OrderId);
        
        OrderNotFoundException.ThrowIfOrderNotFound(orderToUpdate, input.OrderId);

        orderToUpdate.MarkAsPending();
        
        await _orderRepository.ModifyAsync(orderToUpdate);
        
        await _eventBus.DispatchDomainEventAsync(orderToUpdate);

        return CqrsOutput.Succeed();
    }
}
