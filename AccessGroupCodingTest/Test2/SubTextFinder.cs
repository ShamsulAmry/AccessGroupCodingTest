namespace AccessGroupCodingTest.Test2;

public readonly record struct OneBasedIndex(int Index)
{
    public override string ToString() => Index.ToString();
}

public interface ISubTextFinder
{
    IEnumerable<OneBasedIndex> Find(string text, string subText);
}

public class SubTextFinder : ISubTextFinder
{
    private static bool IsEqual(string text, string subText, int textStartAt) =>
        Enumerable
            .Range(0, subText.Length)
            .All(i => char.ToUpper(text[textStartAt + i]) == char.ToUpper(subText[i]));

    public IEnumerable<OneBasedIndex> Find(string text, string subText)
    {
        if (subText.Length == 0)
        {
            yield break;
        }
        
        for (var i = 0; i <= text.Length - subText.Length; i++)
        {
            if (IsEqual(text, subText, i))
            {
                yield return new(i + 1);
            }
        }
    }
}