namespace ChainwideFoodOrderingSystem.Orders.UseCase.OutputPort.Notification;

public interface IPushNotificationClient
{
    Task SendAsync(string to, string title, string message, CancellationToken cancellationToken = default);
}