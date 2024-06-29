using ChainwideFoodOrderingSystem.Orders.WebAPI.Models.CreateOrder;
using FluentValidation;

namespace ChainwideFoodOrderingSystem.Orders.WebAPI.RequestValidators;

public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest> 
{
    public CreateOrderRequestValidator()
    {
        RuleFor(c => c.BuyId)
            .GreaterThan(0)
            .WithErrorCode("")
            .WithMessage("");
    }
}