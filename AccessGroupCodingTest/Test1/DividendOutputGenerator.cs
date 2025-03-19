namespace AccessGroupCodingTest.Test1;

public interface IDividendOutputGenerator
{
    IEnumerable<DividendOutput> Execute(RangeInfoResponse range, DivisorInfoResponse divisors);
}

public class DividendOutputGenerator : IDividendOutputGenerator
{
    public IEnumerable<DividendOutput> Execute(RangeInfoResponse range, DivisorInfoResponse divisors)
    {
        for (var dividend = range.Lower; dividend <= range.Upper; dividend++)
        {
            var divisorOutputs = divisors.OutputDetails
                .Where(it => dividend % it.Divisor == 0)
                .Select(it => it.Output)
                .ToList();

            yield return new(dividend, divisorOutputs);
        }
    }
}