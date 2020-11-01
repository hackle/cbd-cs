using NUnit.Framework;

[TestFixture]
public class MatchResultTests 
{
    [TestCase(10, 20, Result.Loss)]
    [TestCase(20, 10, Result.Win)]
    [TestCase(20, 20, Result.Tie)]
    [Test]
    public void AllScenarios(int myScore, int opponentScore, Result expected)
    {
        var actual = MatchResult.matchResultNoAssign(myScore, opponentScore);

        Assert.That(actual, Is.EqualTo(expected));
    }
}