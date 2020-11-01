using NUnit.Framework;

public class DiscountedTests 
{
    [TestCase(true, true, true, 0.45)]
    [TestCase(true, true, false, 0.65)]
    [TestCase(true, false, true, 0.5)]
    [TestCase(true, false, false, 0.7)]
    [TestCase(false, true, true, 0.55)]
    [TestCase(false, true, false, 0.8)]
    [TestCase(false, false, true, 0.9)]
    [TestCase(false, false, false, 1)]
    [Test]
    public void AllScenarios(bool isBirthday, bool isStudent, bool isRegular, decimal expected)
    {
        var actual = Discounted.Calculate(isBirthday, isStudent, isRegular);

        Assert.That(actual, Is.EqualTo(expected));
    }
}