using System.Collections.Generic;

public static class pairs
{
    static Dictionary<char, char> Pairs = new Dictionary<char, char>
    {
        { '{', '}' },
        { '[', ']' },
        { '<', '>' },
        { '(', ')' },
        { '"', '"' },
        { '\'', '\'' },
    };

    /*
        this is OK but can be more data-oriented than code-oriented
    */
    public static char? End(char open)
    {
        return Pairs.ContainsKey(open) ? (char?) Pairs[open] : null;
    }
}