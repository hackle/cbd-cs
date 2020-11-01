using NUnit.Framework;

public class InflatedIncomeTests 
{
    [Test]
    public void Snowballs() 
    {
        var annualIncome = new decimal[]
        {
            50000, // current year, no inflation
            40000, // a year before
            30000, // 2 years before
        };

        var actual = InflatedIncome.Calculate(annualIncome, 0.02m);

        // disclaimer: not to be taken seriously
        // current year, no inflation yet
        // 50000 + 40000 * 1.02 + 30000 * 1.02 * 1.02
        Assert.That(actual, Is.EqualTo(122012));
    }
}