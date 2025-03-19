namespace AccessGroupCodingTest.Test2;

public interface ISubmitResultsRequestGenerator
{
    SubmitResultsRequest GenerateRequest(TextToSearchResponse textToSearch, SubTextsResponse subTexts);
}