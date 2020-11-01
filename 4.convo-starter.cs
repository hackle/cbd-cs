using System;
using System.Collections.Generic;
using System.Linq;

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

public struct FactMaker 
{ 
    public Func<Person, bool> Test;
    public Func<Person, string> Make;    
}

public static class ConvoStarter
{
    static FactMaker[] FactMakers = new []
    {
        new FactMaker
        {
            Test = person => person.Age != person.FeelsAge,
            Make = person => $"{person.Name} is {person.Age}, but {person.ReferAs} feels like {person.FeelsAge}"
        },
        new FactMaker
        {
            Test = person => person.Age != person.AppearsAge,
            Make = person => $"{person.Name} is {person.Age}, but looks like {person.ReferAs} is {person.AppearsAge}"
        },
        new FactMaker
        {
            Test = person => person.Age > 80 && person.Favourite.Movie == Movie.Frozen,
            Make = person => $"{person.Name} is {person.Age} likes {person.Favourite.Movie}, interesting!"
        },
        new FactMaker
        {
            Test = person => person.Age < 10 && person.Favourite.Sport == Sport.Bowling,
            Make = person => $"{person.Name} is only {person.Age} but already into {person.Favourite.Sport}"
        }
    };
    
    /*
        What are the patterns of the implementation?
        How would you express more succinctly the gathering of conversation starters?
    */
    public static IEnumerable<string> Make(Person person) 
    {
        return FactMakers
                .Where(m => m.Test(person))
                .Select(m => m.Make(person));
    }
}