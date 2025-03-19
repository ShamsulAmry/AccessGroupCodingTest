using AccessGroupCodingTest.Test2;
using FluentAssertions;

namespace AccessGroupCodingTest.Tests.Test2;

public class SubmitResultsRequestGeneratorTests
{
    [Fact]
    public void GenerateRequest_ShouldReturnCorrectResult()
    {
        // Arrange
        ISubmitResultsRequestGenerator sut = null!;
        
        // Act
        var textToSearchResponse = new TextToSearchResponse("Peter told me (actually he slurrred) that peter the pickle piper piped a pitted pickle before he petered out. Phew!");
        var request = sut.GenerateRequest(
            textToSearchResponse,
            new(["Peter", "peter", "Pick", "Pi", "Z"]));
        
        // Assert
        request.Text.Should().Be(textToSearchResponse.Text);
        request.Results.Should().BeEquivalentTo(new SubmitResultsRequestItem[]
        {
            new("Peter", "1, 43, 98"),
            new("peter", "1, 43, 98"),
            new("Pick", "53, 81"),
            new("Pi", "53, 60, 66, 74, 81"),
            new("Z", "<No Output>")
        });
    }
}