namespace ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Command;

/// <summary>
/// 定義一個命令處理器的接口，代表一個執行操作的使用案例。
/// </summary>
/// <typeparam name="TInput">命令的輸入類型。</typeparam>
/// <typeparam name="TOutput">命令的輸出類型。</typeparam>
public interface ICommandHandler<in TInput, TOutput> : IUseCase<TInput, TOutput>
    where TInput : Input
    where TOutput : Output
{
    
}