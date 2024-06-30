namespace ChainwideFoodOrderingSystem.Orders.WebAPI.Models;

public record ApiUniversalResponse<TData>(
    string CorrelationId,
    string ApiVersion,
    string Status,
    string Message,
    TData? Data
);