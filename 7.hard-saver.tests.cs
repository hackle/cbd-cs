using NUnit.Framework;

public class HardSaverTests 
{
    [Test]
    public void Snowballs() 
    {
        var annualIncome = new decimal[]
        {
            50000, // current year, no interest
            40000, // a year before
            30000, // 2 years before
        };

        var actual = HardSaver.AllWithInterest(annualIncome, 0.02m);

        // disclaimer: not to be taken seriously
        // current year, no interest yet
        // 50000 + 40000 * 1.02 + 30000 * 1.02 * 1.02
        Assert.That(actual, Is.EqualTo(122012));
    }
}