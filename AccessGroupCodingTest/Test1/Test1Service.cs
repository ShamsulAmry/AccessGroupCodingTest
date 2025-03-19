namespace AccessGroupCodingTest.Test1;

public interface ITestService
{
    Task<IEnumerable<DividendOutput>> GetDividendOutputsAsync(CancellationToken ct);
}

public class Test1Service(ITest1RemoteApi remoteApi, IDividendOutputGenerator dividendOutputGenerator) : ITestService
{
    public async Task<IEnumerable<DividendOutput>> GetDividendOutputsAsync(CancellationToken ct)
    {
        var rangeTask = RetryPipeline.Instance
            .ExecuteAsync(remoteApi.GetRangeInfoAsync, ct)
            .AsTask();

        var divisorTask = RetryPipeline.Instance
            .ExecuteAsync(remoteApi.GetDivisorInfoAsync, ct)
            .AsTask();

        await Task.WhenAll(rangeTask, divisorTask);

        var range = await rangeTask;
        var divisor = await divisorTask;

        return dividendOutputGenerator.Execute(range, divisor);
    }
}