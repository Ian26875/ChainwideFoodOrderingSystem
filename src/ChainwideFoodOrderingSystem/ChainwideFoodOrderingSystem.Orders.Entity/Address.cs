using ChainwideFoodOrderingSystem.SeedWork.Entity;

namespace ChainwideFoodOrderingSystem.Orders.Entity;

public class Address : ValueObject<Address>
{
    public string Value { get; }
    
    private Address(string value)
    {
        this.Value = value;
    }

    public static implicit operator string(Address self) => self.Value;

    public static Address FromString(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
        }

        return new Address(value);
    }

    public override string ToString() => this.Value;
    
    
}