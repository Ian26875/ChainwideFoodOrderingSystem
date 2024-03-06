namespace ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Query;

/// <summary>
/// 定義一個查詢處理器的接口，用於處理查詢型的使用案例。
/// </summary>
/// <typeparam name="TInput">查詢的輸入類型。</typeparam>
/// <typeparam name="TOutput">查詢的輸出類型。</typeparam>
public interface IQueryHandler<in TInput, TOutput> : IUseCase<TInput, TOutput>
    where TInput : Input
    where TOutput : Output
{
    
}