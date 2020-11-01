using System.Linq;

public static class Discounted
{
    /*
        This is verbose and very error prone.
        Let's make it more data-oriented and declarative
    */
    public static decimal Calculate(bool isBirthday, bool isStudent, bool isRegular) 
    {
        var combos = new []
        {
            new { isBirthday = true, isStudent = true, isRegular = true, final = 0.45m },
            new { isBirthday = true, isStudent = true, isRegular = false, final = 0.65m },
            new { isBirthday = true, isStudent = false, isRegular = true, final = 0.5m },
            new { isBirthday = true, isStudent = false, isRegular = false, final = 0.7m },
            new { isBirthday = false, isStudent = true, isRegular = true, final = 0.55m },
            new { isBirthday = false, isStudent = true, isRegular = false, final = 0.8m },
            new { isBirthday = false, isStudent = false, isRegular = true, final = 0.9m },
            new { isBirthday = false, isStudent = false, isRegular = false, final = 1m },
        };

        return combos.First(c => c.isBirthday == isBirthday && 
                                c.isStudent == isStudent &&
                                c.isRegular == isRegular
                            ).final;
    }
}