using ChainwideFoodOrderingSystem.Orders.WebAPI.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChainwideFoodOrderingSystem.Orders.WebAPI.Infrastructure.ActionFilters;

public class ValidateRequestAttribute : ActionFilterAttribute
{
    private Type RequestArgumentType { get; }

    public ValidateRequestAttribute(Type requestArgumentType)
    {
        this.RequestArgumentType = requestArgumentType;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var argument = context.ActionArguments.Values.SingleOrDefault
        (
            x => x is not null && x.GetType() == RequestArgumentType
        );

        ArgumentNullException.ThrowIfNull(argument, nameof(argument));

        var serviceProvider = context.HttpContext.RequestServices;
        var genericType = typeof(IValidator<>).MakeGenericType(RequestArgumentType);
        var validator = (IValidator) serviceProvider.GetRequiredService(genericType);

        var validationContext = new ValidationContext<object>(argument);
        var validationResult = await validator.ValidateAsync(validationContext);

        if (validationResult.IsValid.Equals(false))
        {
            var errors = validationResult.Errors.Select
            (
                e => new ValidationErrorResponse
                (
                    e.PropertyName, 
                    e.ErrorMessage , 
                    e.ErrorCode
                )
            ).ToList();
            
            context.Result = new BadRequestObjectResult(errors);
            return;
        }

        await next();
    }
}