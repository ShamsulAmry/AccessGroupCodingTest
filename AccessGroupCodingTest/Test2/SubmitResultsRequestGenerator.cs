namespace AccessGroupCodingTest.Test2;

public interface ISubmitResultsRequestGenerator
{
    SubmitResultsRequest GenerateRequest(TextToSearchResponse textToSearch, SubTextsResponse subTexts);
}

public class SubmitResultsRequestGenerator : ISubmitResultsRequestGenerator
{
    public SubmitResultsRequest GenerateRequest(TextToSearchResponse textToSearch, SubTextsResponse subTexts)
    {
        var requestItems = new List<SubmitResultsRequestItem>();
        foreach (var subText in subTexts.SubTexts)
        {
            var output = string.Join(", ", SubTextFinder.Find(textToSearch.Text, subText));
            if (output == "")
            {
                output = SubmitResultsRequestItem.NoMatch;
            }

            requestItems.Add(new(subText, output));
        }

        return new(
            "Shamsul Amry Mokhtar",
            textToSearch.Text,
            requestItems);
    }
}