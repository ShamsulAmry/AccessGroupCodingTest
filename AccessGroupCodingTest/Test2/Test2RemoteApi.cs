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