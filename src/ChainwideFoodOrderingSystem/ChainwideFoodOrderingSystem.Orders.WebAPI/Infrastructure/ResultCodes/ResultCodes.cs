namespace ChainwideFoodOrderingSystem.Orders.WebAPI.Infrastructure.ResultCodes;

public record ResultCodes
{
    public string Value { get; }

    public string Message { get; }

    private ResultCodes(string value,string message)
    {
        this.Value = value;
        this.Message = message;
    }
    
    public static readonly ResultCodes OrderCreated = new ResultCodes("0201", "Order Created Successfully");
    
    public static readonly ResultCodes OrderProcessed = new ResultCodes("0200", "Order Processed Successfully");
    
    public static readonly ResultCodes InvalidRequest = new ResultCodes("0400", "Invalid Order Request");
    
}