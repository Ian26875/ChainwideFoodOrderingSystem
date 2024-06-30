using System.Diagnostics;
using ChainwideFoodOrderingSystem.Orders.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChainwideFoodOrderingSystem.Orders.WebAPI.Infrastructure.ActionFilters;

[AttributeUsage(AttributeTargets.Class| AttributeTargets.Method)]
public class ApiUniversalResponseAttribute : ActionFilterAttribute
{
    public ApiUniversalResponseAttribute()
    {
        Order = 100;
    }
    
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        await next(); 
        if (context.Result is ObjectResult objectResult)
        {
            var traceId = Activity.Current?.Context.TraceId.ToHexString() ?? Guid.NewGuid().ToString();
            var apiVersion = context.HttpContext.Request.RouteValues["version"]?.ToString() ?? "1.0";
            var status = objectResult.StatusCode is >= 200 and < 300 ? "Success" : "Error";
            var message = status == "Success" ? "Request processed successfully." : "An error occurred during the request.";

            var response = new ApiUniversalResponse<object>
            (
                CorrelationId: traceId,
                ApiVersion: apiVersion,
                Status: status,
                Message: message,
                Data: objectResult.Value
            );

            context.Result = new ObjectResult(response);
        }
    }
    
}