using ChainwideFoodOrderingSystem.SeedWork.Entity;

namespace ChainwideFoodOrderingSystem.SeedWork.UseCase.DomainEvents;

/// <summary>
/// 定義事件匯流排的接口，用於發布領域事件。
/// </summary>
public interface IEventBus
{
    /// <summary>
    /// 異步發布一個領域事件。
    /// </summary>
    /// <typeparam name="TDomainEvent">領域事件的類型。</typeparam>
    /// <param name="domainEvent">要發布的領域事件。</param>
    /// <returns>表示異步發布操作的任務。</returns>
    Task PublishAsync<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : DomainEvent;
}
