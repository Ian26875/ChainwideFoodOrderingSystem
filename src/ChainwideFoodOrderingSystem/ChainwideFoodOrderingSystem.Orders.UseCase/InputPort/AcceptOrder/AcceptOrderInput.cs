using ChainwideFoodOrderingSystem.SeedWork.UseCase;

namespace ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.AcceptOrder;

public class AcceptOrderInput : Input
{
    public Guid OrderId { get; }

    public AcceptOrderInput(Guid orderId)
    {
        this.OrderId = orderId;
        this.ValidateSelf();
    }
}