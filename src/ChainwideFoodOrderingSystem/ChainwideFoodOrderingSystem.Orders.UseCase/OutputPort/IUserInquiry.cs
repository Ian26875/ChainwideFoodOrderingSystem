namespace ChainwideFoodOrderingSystem.Orders.UseCase.OutputPort;

public interface IUserInquiry
{
    Task<string> GetDeviceIdAsync(int userId);
}