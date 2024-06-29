using System.Text;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace ChainwideFoodOrderingSystem.Order.IntegrationTests.TestResources;

public sealed class XUnitLogger<T> : XUnitLogger, ILogger<T>
{
    public XUnitLogger(ITestOutputHelper testOutputHelper, LoggerExternalScopeProvider scopeProvider)
        : base(testOutputHelper, scopeProvider, typeof(T).FullName)
    {
    }
}

public class XUnitLogger : ILogger
{
    private readonly string? _categoryName;
    private readonly LoggerExternalScopeProvider _scopeProvider;
    private readonly ITestOutputHelper _testOutputHelper;

    public XUnitLogger(ITestOutputHelper testOutputHelper, LoggerExternalScopeProvider scopeProvider, string? categoryName)
    {
        _testOutputHelper = testOutputHelper;
        _scopeProvider = scopeProvider;
        _categoryName = categoryName;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel != LogLevel.None;
    }
    
    public IDisposable? BeginScope<TState>(TState state)
    {
        return _scopeProvider.Push(state);
    }
    
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception,
                            Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        var sb = new StringBuilder();
        sb.Append(DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        sb.Append(" [").Append(ConvertLogLevelToString(logLevel)).Append("] ");
        sb.Append('[').Append(_categoryName).Append("] ");
        sb.Append(formatter(state, exception));

        if (exception != null)
        {
            sb.AppendLine().Append("Exception: ").Append(exception);
        }

        _scopeProvider.ForEachScope((scope, state) =>
        {
            state.Append(" => ").Append(scope);
        }, sb);

        sb.AppendLine();  // Ensure each log entry is on a new line.

        try
        {
            _testOutputHelper.WriteLine(sb.ToString());
        }
        catch
        {
            // Possible that the test context is finished and output can no longer be written.
        }
    }
    
    private static string ConvertLogLevelToString(LogLevel logLevel)
    {
        return logLevel switch
        {
            LogLevel.Trace => "TRACE",
            LogLevel.Debug => "DEBUG",
            LogLevel.Information => "INFO",
            LogLevel.Warning => "WARN",
            LogLevel.Error => "ERROR",
            LogLevel.Critical => "CRITICAL",
            _ => "UNKNOWN"
        };
    }
}