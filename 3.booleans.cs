public static class Discounted
{
    /*
        This is verbose and very error prone.
        Let's make it more data-oriented and declarative
    */
    public static decimal Calculate(bool isBirthday, bool isStudent, bool isRegular) 
    {
        if (isBirthday && isStudent && isRegular) {
            return 0.45m;
        }

        if (isBirthday && isStudent) {
            return 0.65m;
        }

        if (isBirthday && isRegular) {
            return 0.5m;
        }

        if (isStudent && isRegular) {
            return 0.55m;
        }

        if (isBirthday) {
            return 0.7m;
        }

        if (isStudent) {
            return 0.8m;
        }

        if (isRegular) {
            return 0.9m;
        }

        return 1;
    }
}