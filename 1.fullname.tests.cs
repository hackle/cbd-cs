using NUnit.Framework;

[TestFixture]
public class FullNameTests
{
    [TestCase("Hux", null, "Wan", "Hux Wan")]
    [TestCase("Hux", "Mango", "Wan", "Hux Mango Wan")]
    [Test]
    public void AllScenarios(string firstname, string middlename, string lastname, string expected)
    {
        var actual = FullName.Make(firstname, middlename, lastname);

        Assert.That(actual, Is.EqualTo(expected));
    }
}