using ChainwideFoodOrderingSystem.SeedWork.UseCase;

namespace ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.MarkOrderAsPending;

public class MarkOrderAsPendingInput : Input
{
    public Guid OrderId { get; }

    public MarkOrderAsPendingInput(Guid orderId)
    {
        this.OrderId = orderId;
        this.ValidateSelf();
    }
}