namespace ChainwideFoodOrderingSystem.SeedWork.UseCase;

/// <summary>
/// 代表一個使用案例的輸入參數的抽象基類。
/// </summary>
public abstract class Input :　SelfValidating
{
    protected Input()
    {
        this.ValidateSelf();
    }
}