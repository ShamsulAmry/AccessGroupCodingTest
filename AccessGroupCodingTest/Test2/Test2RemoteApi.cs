namespace AccessGroupCodingTest.Test2;

public record TextToSearchResponse(string Text);
public record SubTextsResponse(IReadOnlyList<string> SubTexts);
public record SubmitResultsRequest(string Candidate, string Text, IReadOnlyList<SubmitResultsRequestItem> Results);

public record SubmitResultsRequestItem(string Subtext, string Result)
{
    public const string NoMatch = "<No Output>";
}

public static class Test2RemoteApiUrls
{
    public const string TextToSearch = "/test2/textToSearch";
    public const string SubTexts = "/test2/subTexts";
    public const string SubmitResults = "/test2/submitResults";
}

public interface ITest2RemoteApi
{
    ValueTask<TextToSearchResponse> GetTextToSearchAsync(CancellationToken ct);
    ValueTask<SubTextsResponse> GetSubTextsAsync(CancellationToken ct);
    ValueTask SubmitResultsAsync(SubmitResultsRequest request, CancellationToken ct);
}

public class Test2RemoteApi(AccessGroupSettings settings, HttpClient httpClient) : ITest2RemoteApi
{
    public async ValueTask<TextToSearchResponse> GetTextToSearchAsync(CancellationToken ct)
    {
        var response = await httpClient.GetAsync(settings.BaseUrl + Test2RemoteApiUrls.TextToSearch, ct);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TextToSearchResponse>(ct) ?? throw new InvalidOperationException();
    }

    public async ValueTask<SubTextsResponse> GetSubTextsAsync(CancellationToken ct)
    {
        var response = await httpClient.GetAsync(settings.BaseUrl + Test2RemoteApiUrls.SubTexts, ct);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<SubTextsResponse>(ct) ?? throw new InvalidOperationException();
    }

    public async ValueTask SubmitResultsAsync(SubmitResultsRequest request, CancellationToken ct)
    {
        var response = await httpClient.PostAsJsonAsync(settings.BaseUrl + Test2RemoteApiUrls.SubmitResults, request, ct);
        response.EnsureSuccessStatusCode();
    }
}