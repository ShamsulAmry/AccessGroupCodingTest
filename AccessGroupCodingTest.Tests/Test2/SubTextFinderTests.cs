using AccessGroupCodingTest.Test2;
using FluentAssertions;

namespace AccessGroupCodingTest.Tests.Test2;

public class SubTextFinderTests
{
    [Theory]
    [InlineData("AAAA", "", new int[0])]
    [InlineData("AAAA", "A", new[] { 1,2,3,4})]
    [InlineData("AAAA", "AA", new[] { 1,2,3})]
    [InlineData("AAAA", "AAA", new[] { 1,2})]
    [InlineData("AAAA", "AAAA", new[] { 1})]
    [InlineData("AAAA", "AAAAA", new int[0])]
    [InlineData("AAAA", "B", new int[0])]
    public void Find_ShouldReturnCorrectResults(string text, string subText, IReadOnlyList<int> expectedResults)
    {
        // Act
        var results = SubTextFinder.Find(text, subText).ToList();
        
        // Assert
        results.Should().BeEquivalentTo(expectedResults.Select(i => new OneBasedIndex(i)));
    }
}