namespace ChainwideFoodOrderingSystem.SeedWork.UseCase;

/// <summary>
/// 代表程式退出代碼的結構。
/// </summary>
public readonly struct ExitCode
{
    /// <summary>
    /// 退出代碼的數值。
    /// </summary>
    public int Code { get; }

    /// <summary>
    /// 退出代碼的描述。
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// 初始化一個新的退出代碼實例。
    /// </summary>
    /// <param name="code">退出代碼的數值。</param>
    /// <param name="description">退出代碼的描述。</param>
    public ExitCode(int code, string description)
    {
        Code = code;
        Description = description;
    }

    /// <summary>
    /// 表示成功的退出代碼。
    /// </summary>
    public static readonly ExitCode Success = new ExitCode(0, "成功");

    /// <summary>
    /// 表示失敗的退出代碼。
    /// </summary>
    public static readonly ExitCode Failure = new ExitCode(1, "失敗");

    /// <summary>
    /// 將退出代碼轉換為其字串表示形式。
    /// </summary>
    /// <returns>退出代碼的字串表示形式，包括數值和描述。</returns>
    public override string ToString()
    {
        return $"{Code}: {Description}";
    }
}