namespace AccessGroupCodingTest.Test1;

public record RangeInfoResponse(int Lower, int Upper);
public record DivisorInfoResponse(IReadOnlyList<DivisorInfoResponseItem> OutputDetails);
public record DivisorInfoResponseItem(int Divisor, string Output);

public static class Test1RemoteApiUrls
{
    public const string RangeInfo = "/test1/rangeinfo";
    public const string DivisorInfo = "/test1/divisorinfo";
}