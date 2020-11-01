
using System.Collections.Generic;
using NUnit.Framework;
public class ConvoStarterTests
{
    public static object[][] Scenarios = new object[][]
    {
        new object[]
        {
            "Feels very young!",
            new Person {
                Name = "George",
                ReferAs = ReferAs.He,
                Age = 80,
                FeelsAge = 25,
                AppearsAge = 79,
                Favourite = new Favourite 
                {
                    Movie = Movie.Godfather,
                    Sport = Sport.Bowling,
                },
            },
            new string[] 
            {
                "George is 80, but He feels like 25",
                "George is 80, but looks like He is 79"
            }
        }
    };
    
    [TestCaseSource(nameof(Scenarios))]
    [Test]
    public void AllScenarios(string scenario, Person person, IEnumerable<string> expected) 
    {
        var actual = ConvoStarter.Make(person);

        Assert.That(actual, Is.EqualTo(expected));
    }
}