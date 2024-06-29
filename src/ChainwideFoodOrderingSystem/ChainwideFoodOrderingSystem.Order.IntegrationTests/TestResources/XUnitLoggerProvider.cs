using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace ChainwideFoodOrderingSystem.Order.IntegrationTests.TestResources;

public sealed class XUnitLoggerProvider : ILoggerProvider
{
    private readonly ITestOutputHelper _testOutputHelper;
    
    private LoggerExternalScopeProvider _loggerExternalScopeProvider;

    public XUnitLoggerProvider(ITestOutputHelper testOutputHelper)
    {
        this._testOutputHelper = testOutputHelper;
        _loggerExternalScopeProvider = new LoggerExternalScopeProvider();
    }
    
    public ILogger CreateLogger(string categoryName)
    {
        return new XUnitLogger(_testOutputHelper, _loggerExternalScopeProvider, categoryName);
    }

    public void Dispose()
    {
        _loggerExternalScopeProvider = null;
    }
}