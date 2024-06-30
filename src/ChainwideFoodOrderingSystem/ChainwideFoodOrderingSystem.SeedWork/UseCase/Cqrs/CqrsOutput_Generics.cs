namespace ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs;

public sealed class CqrsOutput<TId> : CqrsOutput
{
    /// <summary>
    /// 獲取或設置識別碼。
    /// </summary>
    public TId Id { get; private set; }

    /// <summary>
    /// 創建一個表示成功的輸出結果。
    /// </summary>
    /// <returns>表示成功的輸出結果。</returns>
    public static CqrsOutput<TId> Succeed()
    {
        return new CqrsOutput<TId>
        {
            ExitCode = ExitCode.Success
        };
    }

    /// <summary>
    /// 創建一個表示失敗的輸出結果。
    /// </summary>
    /// <returns>表示失敗的輸出結果。</returns>
    public static CqrsOutput<TId> Fail()
    {
        return new CqrsOutput<TId>
        {
            ExitCode = ExitCode.Failure
        };
    }

    /// <summary>
    /// 設置識別碼並返回當前實例，以便進行鏈式調用。
    /// </summary>
    /// <param name="id">要設置的識別碼。</param>
    /// <returns>帶有設置的識別碼的當前實例。</returns>
    public CqrsOutput<TId> WithId(TId id)
    {
        this.Id = id;
        return this;
    }
}
