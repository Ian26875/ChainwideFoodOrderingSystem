namespace ChainwideFoodOrderingSystem.SeedWork.UseCase;

/// <summary>
/// 定義一個使用案例（Use Case）的接口。
/// </summary>
/// <typeparam name="TInput">使用案例的輸入類型。</typeparam>
/// <typeparam name="TOutput">使用案例的輸出類型。</typeparam>
public interface IUseCase<in TInput, TOutput> where TInput : Input
                                              where TOutput : Output
{
    /// <summary>
    /// 異步執行使用案例。
    /// </summary>
    /// <param name="input">使用案例的輸入參數。</param>
    /// <param name="cancellationToken">取消操作的通知。</param>
    /// <returns>使用案例的輸出結果。</returns>
    Task<TOutput> ExecuteAsync(TInput input, CancellationToken cancellationToken = default);
}