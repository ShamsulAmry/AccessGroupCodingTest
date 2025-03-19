namespace AccessGroupCodingTest.Test2;

public static class Test2ServiceCollectionExtension
{
    public static IServiceCollection AddTest2(this IServiceCollection services)
    {
        services.AddSingleton<ITest2Service, Test2Service>();
        services.AddSingleton<ISubmitResultsRequestGenerator, SubmitResultsRequestGenerator>();
        services.AddHttpClient<ITest2RemoteApi, Test2RemoteApi>().AddHttpMessageHandler<OutboundHttpRequestLogger>();
        services.AddSingleton<OutboundHttpRequestLogger>();

        return services;
    }
}

// ReSharper disable once ClassNeverInstantiated.Global
internal class OutboundHttpRequestLogger(ILogger<OutboundHttpRequestLogger> logger) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        if (logger.IsEnabled(LogLevel.Debug) && request.Method == HttpMethod.Post)
        {
            var requestBody = await request.Content!.ReadAsStringAsync(ct);
            logger.LogDebug("HTTP request body:\n{RequestBody:l}", requestBody);
        }

        return await base.SendAsync(request, ct);
    }
}