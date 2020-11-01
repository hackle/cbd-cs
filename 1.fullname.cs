using System.Linq;

public static class FullName 
{
    /*
        The current solution is imperative, and buggy.
        1) try to write a failing test
    */
    public static string Make(
        string firstname, 
        string middlename, 
        string lastname
    ) 
    {
        var fullname = string.Empty;
        if (firstname != null) {
            fullname += firstname;
        }

        if (middlename != null) {
            fullname += ' ' + middlename;
        }

        if (lastname != null) {
            fullname += ' ' + lastname;
        }

        return fullname;
    }

    /*
        full name is first, middle and last name put together,
        whichever exists, 
        and separated with a whitespace
    */
    public static string Make1(
        string firstname, 
        string middlename, 
        string lastname) 
    {
        return string.Join(
            " ",
            new [] { firstname, middlename, lastname }
                .Where(n => string.IsNullOrWhiteSpace(n))
        );
    }
}