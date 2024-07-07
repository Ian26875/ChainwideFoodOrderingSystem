using ChainwideFoodOrderingSystem.Orders.WebAPI.Infrastructure.ResultCodes;
using ChainwideFoodOrderingSystem.Orders.WebAPI.Models.CreateOrder;
using FluentValidation;

namespace ChainwideFoodOrderingSystem.Orders.WebAPI.RequestValidators;

public class CreateOrderRequestValidator : AbstractValidator<PlaceOrderRequest> 
{
    public CreateOrderRequestValidator()
    {
        RuleFor(c => c.BuyId)
            .GreaterThan(0)
            .WithErrorCode(ResultCodes.OrderCreated.Value)
            .WithMessage("");
    }
}