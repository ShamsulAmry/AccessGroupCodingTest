namespace AccessGroupCodingTest.Test2;

public interface ITest2Service
{
    IEnumerable<SubmitResultsRequestItem> Execute(TextToSearchResponse textToSearch, SubTextsResponse subTexts);
}