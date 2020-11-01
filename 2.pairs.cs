public static class pairs
{
    /*
        this is OK but can be more data-oriented than code-oriented
    */
    public static char? End(char open)
    {
        switch (open) {
            case '{': return '}';
            case '[': return ']';
            case '<': return '>';
            case '(': return ')';
            case '"': return '"';
            case '\'': return '\'';
        }

        return null;
    }
}