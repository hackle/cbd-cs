using System.Collections.Generic;
using System.Linq;

public static class Footy
{
    /*
        See spec file for problem statement
        Maybe there is a useful function from Linq
    */
    public static IEnumerable<string> Pass(IEnumerable<string> players)
    {
        return players.Zip(
            players.Skip(1).Concat(players.Take(1)),
            (p1, p2) => $"{p1} passes the ball to {p2}"
        );
    }
}