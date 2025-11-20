using System.Text.RegularExpressions;

namespace HabitTracker.UserInterface;

public static class Input
{
    public static int ValidInt()
    {
        string? userInput = Console.ReadLine();
        int validInput;

        while (!int.TryParse(userInput, out validInput))
        {
            Console.WriteLine("Please enter a valid integer");
            userInput = Console.ReadLine();
        }
        return validInput;
    }

    public static string ValidDate()
    {
        Regex rg = new Regex(@"^(0[1-9]|1[0-2])\/(0[1-9]|[12]\d|3[01])\/\d{4}$");
        
        string? userInput = Console.ReadLine();

        while (!rg.IsMatch(userInput) && userInput != "now")
        {
            Console.WriteLine("Please enter a valid date");
            userInput = Console.ReadLine();
        }
        
        return userInput;
    }
}