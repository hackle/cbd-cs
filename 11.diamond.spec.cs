using NUnit.Framework;

public class DiamondTests
{
    [Test]
    public void DiamondWithLetterD()
    {
        string expected = 
@"---A---
--B-B--
-C---C-
D-----D
-C---C-
--B-B--
---A---";

        var actual = Diamond.Make('D');
        Assert.That(actual, Is.EqualTo(expected));
    }
}