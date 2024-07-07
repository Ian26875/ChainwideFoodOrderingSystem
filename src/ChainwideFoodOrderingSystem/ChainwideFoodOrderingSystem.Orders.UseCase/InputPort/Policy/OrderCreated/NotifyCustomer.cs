using ChainwideFoodOrderingSystem.Orders.Entity.DomainEvents;
using ChainwideFoodOrderingSystem.Orders.UseCase.OutputPort;
using ChainwideFoodOrderingSystem.Orders.UseCase.OutputPort.Notification;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.DomainEvents;

namespace ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.Policy.OrderCreated;
/// <summary>
/// 負責通知客戶的類別。
/// </summary>
/// <seealso cref="IEventHandler{OrderCreatedEvent}"/>
public class NotifyCustomer : IEventHandler<OrderCreatedEvent>
{
    /// <summary>
    /// 推送通知客戶端。
    /// </summary>
    private readonly IPushNotificationClient _pushNotificationClient;

    /// <summary>
    /// 用戶查詢接口。
    /// </summary>
    private readonly IUserInquiry _userInquiry;
    
    /// <summary>
    /// 初始化 <see cref="NotifyCustomer"/> 類的新實例。
    /// </summary>
    /// <param name="pushNotificationClient">推送通知客戶端。</param>
    /// <param name="userInquiry">用戶查詢接口。</param>
    public NotifyCustomer(IPushNotificationClient pushNotificationClient, IUserInquiry userInquiry)
    {
        _pushNotificationClient = pushNotificationClient;
        _userInquiry = userInquiry;
    }

    /// <summary>
    /// 處理領域事件。
    /// </summary>
    /// <param name="domainEvent">領域事件。</param>
    /// <param name="cancellationToken">取消令牌。</param>
    public async Task HandleAsync(OrderCreatedEvent domainEvent, CancellationToken cancellationToken =  default)
    {
        // 從用戶查詢接口獲取用戶的設備識別碼
        string userDeviceIdentifier = await _userInquiry.GetDeviceIdAsync(domainEvent.BuyId); 
        
        // 通知標題
        string notificationTitle = "訂單已成立";
        
        // 通知內容
        string notificationMessage = $"您的訂單 {domainEvent.OrderId} 已成功創建。";
        
        // 發送推送通知
        await _pushNotificationClient.SendAsync
        (
            userDeviceIdentifier, 
            notificationTitle, 
            notificationMessage, 
            cancellationToken
        );
    }
}
