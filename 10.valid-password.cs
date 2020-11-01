using System;
using System.Text.RegularExpressions;

public static class PasswordManager
{
    /*
        This is imperative - see if you can express it more succinctly
    */
    public static string GetValidPassword() 
    {
        string password;
        var isValid = false;
        do {
            password = Question("Please input a password: ");
            isValid = password.Length > 8 && 
                        Regex.IsMatch(password, "[a-z]", RegexOptions.IgnoreCase) && 
                        Regex.IsMatch(password, "[0-9]");

            Console.WriteLine($"\"{password}\" is valid? {isValid}");
        } while (!isValid);

        return password;
    }

    static string Question(string question) 
    {
        Console.WriteLine(question);
        return Console.ReadLine();    
    }
}

// to run, do dotnet run