using ChainwideFoodOrderingSystem.SeedWork.Entity;

namespace ChainwideFoodOrderingSystem.SeedWork.UseCase.DomainEvents;

/// <summary>
///     事件匯流排擴充方法的靜態類別。
/// </summary>
public static class EventBusExtensions
{

    /// <summary>
    /// 異步分發聚合根中的未提交的領域事件。
    /// </summary>
    /// <typeparam name="TId">聚合根的識別碼類型。</typeparam>
    /// <param name="eventBus">事件匯流排的實例。</param>
    /// <param name="aggregateRoot">聚合根的實例。</param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <returns>一個 Task，代表異步操作。</returns>
    public static async Task DispatchDomainEventAsync<TId>(this IEventBus eventBus, 
                                                           AggregateRoot<TId> aggregateRoot) where TId : ValueObject<TId>
    {
        if (eventBus is null)
        {
            throw new ArgumentNullException(nameof(eventBus));
        }

        if (aggregateRoot is null)
        {
            throw new ArgumentNullException(nameof(aggregateRoot));
        }

        foreach (var domainEvent in aggregateRoot.GetUncommittedChanges())
        {
            await eventBus.PublishAsync(domainEvent);
        }

        aggregateRoot.ClearUncommittedChanges();
    }
}