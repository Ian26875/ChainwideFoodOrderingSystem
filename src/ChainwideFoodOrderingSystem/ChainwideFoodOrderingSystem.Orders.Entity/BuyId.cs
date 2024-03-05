using ChainwideFoodOrderingSystem.SeedWork.DomainModel;

namespace ChainwideFoodOrderingSystem.Orders.Entity;

public class BuyId : ValueObject<BuyId>
{
    public int Value { get;}
    
    private BuyId(int value)
    {
        this.Value = value;
    }

    public static implicit operator int(BuyId self) => self.Value;

    public static implicit operator BuyId(int value) => new BuyId(value);

    public override string ToString() => this.Value.ToString();
}