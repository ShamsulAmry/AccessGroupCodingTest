// ReSharper disable ClassNeverInstantiated.Global

namespace AccessGroupCodingTest.Test1;

public record RangeInfoResponse(int Lower, int Upper);
public record DivisorInfoResponse(IReadOnlyList<DivisorInfoResponseItem> OutputDetails);
public record DivisorInfoResponseItem(int Divisor, string Output);

public static class Test1RemoteApiUrls
{
    public const string RangeInfo = "/test1/rangeinfo";
    public const string DivisorInfo = "/test1/divisorinfo";
}

public interface ITest1RemoteApi
{
    ValueTask<RangeInfoResponse> GetRangeInfoAsync(CancellationToken ct);
    ValueTask<DivisorInfoResponse> GetDivisorInfoAsync(CancellationToken ct);
}

public class Test1RemoteApi(AccessGroupSettings settings, HttpClient httpClient) : ITest1RemoteApi
{
    public async ValueTask<RangeInfoResponse> GetRangeInfoAsync(CancellationToken ct)
    {
        var response = await httpClient.GetAsync(settings.BaseUrl + Test1RemoteApiUrls.RangeInfo, ct);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<RangeInfoResponse>(ct) ?? throw new InvalidOperationException();
    }

    public async ValueTask<DivisorInfoResponse> GetDivisorInfoAsync(CancellationToken ct)
    {
        var response = await httpClient.GetAsync(settings.BaseUrl + Test1RemoteApiUrls.DivisorInfo, ct);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<DivisorInfoResponse>(ct) ?? throw new InvalidOperationException();
    }
}