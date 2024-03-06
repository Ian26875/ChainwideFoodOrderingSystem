namespace ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Query;

/// <summary>
/// 定義一個檔案庫的接口，用於存取和管理特定類型的資料。
/// </summary>
/// <typeparam name="T">資料的類型。</typeparam>
/// <typeparam name="TId">資料的識別碼類型。</typeparam>
public interface IArchive<T, in TId>
{
    /// <summary>
    /// 異步查找指定識別碼的資料。
    /// </summary>
    /// <param name="id">資料的識別碼。</param>
    /// <returns>找到的資料，如果未找到則返回 null。</returns>
    Task<T> FindAsync(TId id);

    /// <summary>
    /// 異步保存資料。
    /// </summary>
    /// <param name="data">要保存的資料。</param>
    /// <returns>一個表示異步保存操作的任務。</returns>
    Task SaveAsync(T data);

    /// <summary>
    /// 異步修改資料。
    /// </summary>
    /// <param name="data">要修改的資料。</param>
    /// <returns>一個表示異步修改操作的任務。</returns>
    Task ModifyAsync(T data);
}