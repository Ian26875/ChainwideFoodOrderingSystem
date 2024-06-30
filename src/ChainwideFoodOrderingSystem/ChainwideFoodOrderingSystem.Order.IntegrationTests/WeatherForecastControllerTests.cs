using ChainwideFoodOrderingSystem.Order.IntegrationTests.TestResources;
using ChainwideFoodOrderingSystem.Orders.WebAPI;
using FluentAssertions;
using Xunit.Abstractions;

namespace ChainwideFoodOrderingSystem.Order.IntegrationTests;

public class WeatherForecastControllerTests 
{
  

    public WeatherForecastControllerTests(ITestOutputHelper testOutputHelper)
    {
        TestOutputHelper = testOutputHelper;
        TestWebApplicationFactory = new TestWebApplicationFactory<Program>(TestOutputHelper);
        HttpClient = TestWebApplicationFactory.CreateDefaultClient(new HttpClientLogger(TestOutputHelper));
    }

    private TestWebApplicationFactory<Program> TestWebApplicationFactory { get; }
    
    private ITestOutputHelper TestOutputHelper { get; }

    private HttpClient HttpClient { get; }

    [Fact]
    public async Task Test_GetWeatherForecast_ReturnsValidForecasts()
    {
        // arrange
        var requestUri = "api/V1/WeatherForecast";

        // act
        var response = await HttpClient.GetAsync(requestUri);

        // assert
        response.Should().Be200Ok()
            .And
            .Satisfy<List<WeatherForecast>>(w => w.Should().HaveCount(5));
    }
}