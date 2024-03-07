using ChainwideFoodOrderingSystem.SeedWork.Entity;

namespace ChainwideFoodOrderingSystem.SeedWork.UseCase.DomainEvents;

/// <summary>
/// 定義事件處理器的介面，用於處理特定類型的領域事件。
/// </summary>
/// <typeparam name="TDomainEvent">領域事件的類型。</typeparam>
public interface IEventHandler<in TDomainEvent> where TDomainEvent : DomainEvent
{
    /// <summary>
    /// 異步處理領域事件。
    /// </summary>
    /// <param name="domainEvent">要處理的領域事件。</param>
    /// <param name="cancellationToken"></param>
    /// <returns>表示異步處理操作的任務。</returns>
    Task HandleAsync(TDomainEvent domainEvent,CancellationToken cancellationToken);
}
