namespace AccessGroupCodingTest.Test2;

public interface ISubmitResultsRequestGenerator
{
    SubmitResultsRequest GenerateRequest(TextToSearchResponse textToSearch, SubTextsResponse subTexts);
}

public class SubmitResultsRequestGenerator : ISubmitResultsRequestGenerator
{
    public SubmitResultsRequest GenerateRequest(TextToSearchResponse textToSearch, SubTextsResponse subTexts)
    {
        var outputCache = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        var requestItems = new List<SubmitResultsRequestItem>();
        foreach (var subText in subTexts.SubTexts)
        {
            if (!outputCache.TryGetValue(subText, out var output))
            {
                output = string.Join(", ", SubTextFinder.Find(textToSearch.Text, subText));
                if (output == "")
                {
                    output = SubmitResultsRequestItem.NoMatch;
                }

                outputCache.Add(subText, output);
            }

            requestItems.Add(new(subText, output));
        }

        return new(
            "Shamsul Amry Mokhtar",
            textToSearch.Text,
            requestItems);
    }
}