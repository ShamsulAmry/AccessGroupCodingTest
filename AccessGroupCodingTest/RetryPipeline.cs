using Polly;
using Polly.Retry;

namespace AccessGroupCodingTest;

public static class RetryPipeline
{
    static RetryPipeline()
    {
        var optionsComplex = new RetryStrategyOptions
        {
            BackoffType = DelayBackoffType.Exponential,
            UseJitter = true, // Adds a random factor to the delay
            MaxRetryAttempts = int.MaxValue
        };

        Instance = new ResiliencePipelineBuilder()
            .AddRetry(optionsComplex)
            .Build();
    }

    public static ResiliencePipeline Instance { get; }
}