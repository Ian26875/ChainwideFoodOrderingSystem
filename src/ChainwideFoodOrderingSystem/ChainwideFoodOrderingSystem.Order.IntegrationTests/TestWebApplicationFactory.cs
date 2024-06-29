using ChainwideFoodOrderingSystem.Order.IntegrationTests.TestResources;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;


namespace ChainwideFoodOrderingSystem.Order.IntegrationTests;

public class TestWebApplicationFactory <TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    private readonly ITestOutputHelper _testOutputHelper;

    public TestWebApplicationFactory(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.Services.AddSingleton<ILoggerProvider>(new XUnitLoggerProvider(_testOutputHelper));
        });
        
        base.ConfigureWebHost(builder);
    }
}