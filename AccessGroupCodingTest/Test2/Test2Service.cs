namespace AccessGroupCodingTest.Test2;

public interface ITest2Service
{
    Task ExecuteAsync(CancellationToken ct);
}

public class Test2Service(ITest2RemoteApi remoteApi, ISubmitResultsRequestGenerator requestGenerator) : ITest2Service
{
    public async Task ExecuteAsync(CancellationToken ct)
    {
        var textToSearchTask = RetryPipeline.Instance
            .ExecuteAsync(remoteApi.GetTextToSearchAsync, ct)
            .AsTask();

        var subTextsTask = RetryPipeline.Instance
            .ExecuteAsync(remoteApi.GetSubTextsAsync, ct)
            .AsTask();

        await Task.WhenAll(textToSearchTask, subTextsTask);

        var textToSearch = await textToSearchTask;
        var subTexts = await subTextsTask;
        var request = requestGenerator.GenerateRequest(textToSearch, subTexts);

        await RetryPipeline.Instance
            .ExecuteAsync(innerCt => remoteApi.SubmitResultsAsync(request, innerCt), ct);
    }
}