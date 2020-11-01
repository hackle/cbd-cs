using System;
using System.Linq;

public static class Diamond
{
    /*
        given any letter, build a diamond shape.
        For example, with D
        ---A---
        --B-B--
        -C---C-
        D-----D
        -C---C-
        --B-B--
        ---A---
    */
    public static string Make(char letter)
    {
        var half = Enumerable.Range('A', char.ToUpper(letter) - 'A' + 1)
                    .Select(c => MakeLine(c, letter));
        return string.Join(
            Environment.NewLine,
            half.Concat(half.Reverse().Skip(1))
        );
    }

    static string MakeLine(int cur, int end)
    {
        var half = Enumerable.Range('A', end - 'A' + 1);
        return string.Join("", 
                half.Skip(1).Reverse()
                    .Concat(half)
                    .Select(c => c == cur ? (char)c : '-'));
    }
}