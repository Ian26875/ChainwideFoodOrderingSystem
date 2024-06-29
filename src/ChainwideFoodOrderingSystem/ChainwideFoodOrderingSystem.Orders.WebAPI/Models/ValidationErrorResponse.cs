namespace ChainwideFoodOrderingSystem.Orders.WebAPI.Models;

public class ValidationErrorResponse
{
    public string Field { get; set; } 
    public string Message { get; set; } 
    public string Code { get; set; } 

    public ValidationErrorResponse(string field, string message, string code = null)
    {
        Field = field;
        Message = message;
        Code = code;
    }
}