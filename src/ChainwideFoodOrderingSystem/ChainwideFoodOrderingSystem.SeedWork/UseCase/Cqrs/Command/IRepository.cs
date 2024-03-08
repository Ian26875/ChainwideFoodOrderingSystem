using ChainwideFoodOrderingSystem.SeedWork.Entity;

namespace ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Command;

/// <summary>
/// 定義一個存儲庫的接口，用於存取和管理聚合根實體。
/// </summary>
/// <typeparam name="TAggregateRoot">聚合根的類型。</typeparam>
/// <typeparam name="TId">聚合根的識別碼類型。</typeparam>
public interface IRepository<TAggregateRoot, in TId> 
    where TAggregateRoot : AggregateRoot<TId> 
    where TId : ValueObject<TId>
{
    
    /// <summary>
    /// 異步查找指定識別碼的聚合根實體。
    /// </summary>
    /// <param name="id">聚合根的識別碼。</param>
    /// <returns>找到的聚合根實體，如果未找到則返回 null。</returns>
    Task<TAggregateRoot> FindAsync(TId id);

    /// <summary>
    /// 異步保存聚合根實體。
    /// </summary>
    /// <param name="aggregateRoot">要保存的聚合根實體。</param>
    /// <returns>保存後的聚合根實體。</returns>
    Task<TAggregateRoot> SaveAsync(TAggregateRoot aggregateRoot);

    /// <summary>
    /// 異步修改聚合根實體。
    /// </summary>
    /// <param name="aggregateRoot">要修改的聚合根實體。</param>
    /// <returns>修改後的聚合根實體。</returns>
    Task<TAggregateRoot> ModifyAsync(TAggregateRoot aggregateRoot);
}