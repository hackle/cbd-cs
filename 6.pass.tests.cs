using NUnit.Framework;

public class FootyTests
{
    public void PassesInACircle()
    {
        var actual = Footy.Pass(new [] { "Adam", "Bela", "Charles", "Diane" });

        Assert.That(actual, Is.EqualTo(new []
        {
            "Adam passes the ball to Bela",
            "Bela passes the ball to Charles",
            "Charles passes the ball to Diane",
            "Diane passes the ball to Adam"
        }));
    }
}