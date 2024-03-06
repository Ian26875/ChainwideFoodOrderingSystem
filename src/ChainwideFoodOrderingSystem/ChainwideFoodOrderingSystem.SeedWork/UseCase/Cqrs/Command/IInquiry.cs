namespace ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Command;

/// <summary>
/// 定義一個查詢的接口，代表一個不會改變系統狀態的使用案例。
/// </summary>
/// <typeparam name="TInput">查詢的輸入類型。</typeparam>
/// <typeparam name="TOutput">查詢的輸出類型。</typeparam>
public interface IInquiry<in TInput, TOutput>
{
    /// <summary>
    /// 異步執行查詢操作。
    /// </summary>
    /// <param name="input">查詢的輸入參數。</param>
    /// <returns>查詢的結果。</returns>
    Task<TOutput> QueryAsync(TInput input);
}