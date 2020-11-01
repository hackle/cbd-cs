using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class PasswordManager
{
    public static string GetValidPassword() 
    {
        return Enumerable.Range(0, 100)
            .Select(_ => GetOnce())
            .First(p => p != null);
    }

    static string GetOnce()
    {
        var password = Question("Please input a password: ");
        var isValid = IsValid(password);
        Console.WriteLine($"\"{password}\" is valid? {isValid}");

        return isValid ? password : null;
    }

    static bool IsValid(string password) 
    {
        return password.Length > 8 && 
                        Regex.IsMatch(password, "[a-z]", RegexOptions.IgnoreCase) && 
                        Regex.IsMatch(password, "[0-9]");
    }

    static string Question(string question) 
    {
        Console.WriteLine(question);
        return Console.ReadLine();    
    }
}

// to run, do dotnet run