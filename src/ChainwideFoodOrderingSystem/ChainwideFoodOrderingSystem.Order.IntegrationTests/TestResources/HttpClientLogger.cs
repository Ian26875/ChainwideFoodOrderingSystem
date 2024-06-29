using System.Diagnostics;
using Xunit.Abstractions;

namespace ChainwideFoodOrderingSystem.Order.IntegrationTests.TestResources;

public class HttpClientLogger : DelegatingHandler
{
    private readonly ITestOutputHelper _testOutputHelper;

    public HttpClientLogger(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        await LogHttpRequestAsync(request);
        
        var stopwatch = Stopwatch.StartNew(); 
        
        var response = await base.SendAsync(request, cancellationToken);
        
        stopwatch.Stop(); 
        
        await LogHttpResponseAsync(response, stopwatch.Elapsed);
        
        return response;
    }
    
    private async Task LogHttpRequestAsync(HttpRequestMessage request)
    {
        _testOutputHelper.WriteLine($"Request Method: {request.Method}");
        _testOutputHelper.WriteLine($"Request URL: {request.RequestUri}");
        foreach (var header in request.Headers)
        {
            _testOutputHelper.WriteLine($"Request Header: {header.Key} - {string.Join(", ", header.Value)}");
        }
        if (request.Content != null)
        {
            var content = await request.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine($"Request Content: {content}");
        }
    }

    private async Task LogHttpResponseAsync(HttpResponseMessage response, TimeSpan duration)
    {
        _testOutputHelper.WriteLine($"Response Http Code: {response.StatusCode}");
        _testOutputHelper.WriteLine($"Response Time: {duration.TotalMilliseconds} ms");
        
        foreach (var header in response.Headers)
        {
            _testOutputHelper.WriteLine($"Response Header: {header.Key} - {string.Join(", ", header.Value)}");
        }
        var content = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine($"Response Content: {content}");
    }
}
