using NUnit.Framework;

public class SceneExplainerTests
{
    [TestCaseSource(nameof(Scenarios))]
    [Test]
    public void AllScenarios(string scenario, Scene scene, string expected)
    {
        var actual = SceneExplainer.Explain(scene);

        Assert.That(actual, Is.EqualTo(expected));
    }

    public static object[][] Scenarios = new object[][]
    {
        new object[]
        {
            "Family greeting",
            new Scene
            {
                Action = Action.Greeting,
                Person1 = "Mary",
                Person2 = "John",
                Place = Place.Home
            },
            "Mary gives John a bear hug"
        },
        new object[] {
            "Family disagreement",
            new Scene
            {
                Action = Action.Disagreement,
                Person1 = "Mary",
                Person2 = "John",
                Place = Place.Home
            },
            "Mary shouts to John: I hate you!"
        },
        new object[]
        {
            "Workplace greeting",
            new Scene
            {
                Action = Action.Greeting,
                Person1 = "Mary",
                Person2 = "John",
                Place = Place.Office
            } ,
            "Mary shares a firm hand-shake with John"
        },
        new object[]
        {
            "Workplace disagreement",
            new Scene
            {
                Action = Action.Disagreement,
                Person1 = "Mary",
                Person2 = "John",
                Place = Place.Office
            } ,
            "Mary addresses John: I beg to differ"
        }
    };
}