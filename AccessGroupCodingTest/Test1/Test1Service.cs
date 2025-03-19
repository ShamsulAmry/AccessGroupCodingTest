namespace AccessGroupCodingTest.Test1;

public interface ITest1Service
{
    IEnumerable<DividendInfo> Execute(RangeInfoResponse range, DivisorInfoResponse divisors);
}