using System.Collections.Generic;

public enum ReferAs { She, He }
public enum Movie { Frozen, Tenet, Godfather }
public enum Sport { Swimming, Bowling, MountainBiking }
public struct Favourite 
{
    public Movie Movie;
    public Sport Sport;
}
public struct Person
{
    public string Name;
    public ReferAs ReferAs;
    public int Age;
    public int FeelsAge;
    public int AppearsAge;
    public Favourite Favourite;
};

public static class ConvoStarter
{
    /*
        What are the patterns of the implementation?
        How would you express more succinctly the gathering of conversation starters?
    */
    public static IEnumerable<string> Make(Person person) 
    {
        var facts = new List<string>();

        if (person.Age != person.FeelsAge) {
            facts.Add($"{person.Name} is {person.Age}, but {person.ReferAs} feels like {person.FeelsAge}");
        }

        if (person.Age != person.AppearsAge) {
            facts.Add($"{person.Name} is {person.Age}, but looks like {person.ReferAs} is {person.AppearsAge}");
        }

        if (person.Age > 80 && person.Favourite.Movie == Movie.Frozen) {
            facts.Add($"{person.Name} is {person.Age} likes {person.Favourite.Movie}, interesting!");
        }

        if (person.Age < 10 && person.Favourite.Sport == Sport.Bowling) {
            facts.Add($"{person.Name} is only {person.Age} but already into {person.Favourite.Sport}");
        }

        return facts;
    }
}