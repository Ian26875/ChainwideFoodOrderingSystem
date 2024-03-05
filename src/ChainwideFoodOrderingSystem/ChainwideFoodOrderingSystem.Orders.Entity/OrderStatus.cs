namespace ChainwideFoodOrderingSystem.Orders.Entity;

/// <summary>
///     訂單狀態
/// </summary>
public enum OrderStatus
{
    /// <summary>
    ///     訂單已提交，等待處理
    /// </summary>
    Pending,

    /// <summary>
    ///     訂單已被餐廳接受
    /// </summary>
    Accepted,

    /// <summary>
    ///     訂單被餐廳拒絕
    /// </summary>
    Rejected,

    /// <summary>
    ///     餐點正在準備中
    /// </summary>
    Preparing,

    /// <summary>
    ///     餐點準備完成，等待外送
    /// </summary>
    ReadyForDelivery,

    /// <summary>
    ///     餐點正在外送途中
    /// </summary>
    OutForDelivery,

    /// <summary>
    ///     餐點已送達
    /// </summary>
    Delivered,

    /// <summary>
    ///     訂單已完成
    /// </summary>
    Completed,

    /// <summary>
    ///     訂單已取消
    /// </summary>
    Cancelled
}