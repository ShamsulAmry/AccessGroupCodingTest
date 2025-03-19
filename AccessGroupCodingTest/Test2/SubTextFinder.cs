namespace AccessGroupCodingTest.Test2;

public record struct OneBasedIndex(int Index);

public interface ISubTextFinder
{
    IEnumerable<OneBasedIndex> Find(string text, string subText);
}