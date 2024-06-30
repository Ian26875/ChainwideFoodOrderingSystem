using Asp.Versioning;
using ChainwideFoodOrderingSystem.Orders.WebAPI.Infrastructure.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace ChainwideFoodOrderingSystem.Orders.WebAPI.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]

public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [ApiUniversalResponse]
    public IActionResult Get()
    {
        this._logger.LogInformation("Execute WeatherForecastController - Get()");
        var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

        return Ok(weatherForecasts);
    }
}