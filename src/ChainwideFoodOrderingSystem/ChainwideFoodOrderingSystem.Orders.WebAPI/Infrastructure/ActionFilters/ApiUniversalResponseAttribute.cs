using System.Diagnostics;
using ChainwideFoodOrderingSystem.Orders.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChainwideFoodOrderingSystem.Orders.WebAPI.Infrastructure.ActionFilters;

/// <summary>
/// The api universal response attribute class
/// </summary>
/// <seealso cref="ActionFilterAttribute"/>
[AttributeUsage(AttributeTargets.Class| AttributeTargets.Method)]
public class ApiUniversalResponseAttribute : ActionFilterAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiUniversalResponseAttribute"/> class
    /// </summary>
    public ApiUniversalResponseAttribute()
    {
        Order = 100;
    }
    

    /// <summary>
    /// Ons the action executed using the specified context
    /// </summary>
    /// <param name="context">The context</param>
    public override void OnActionExecuted(ActionExecutedContext context)
    {
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