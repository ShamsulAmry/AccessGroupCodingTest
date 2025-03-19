namespace AccessGroupCodingTest.Test2;

public static class Test2ServiceCollectionExtension
{
    public static IServiceCollection AddTest2(this IServiceCollection services)
    {
        services.AddSingleton<ITest2Service, Test2Service>();
        services.AddSingleton<ITest2RemoteApi, Test2RemoteApi>();
        services.AddSingleton<ISubmitResultsRequestGenerator, SubmitResultsRequestGenerator>();

        return services;
    }
}