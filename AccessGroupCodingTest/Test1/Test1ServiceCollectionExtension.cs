namespace AccessGroupCodingTest.Test1;

public static class Test1ServiceCollectionExtension
{
    public static IServiceCollection AddTest1(this IServiceCollection services)
    {
        services.AddSingleton<ITestService, Test1Service>();
        services.AddSingleton<IDividendOutputGenerator, DividendOutputGenerator>();
        services.AddSingleton<ITest1RemoteApi, Test1RemoteApi>();

        return services;
    }
}