using HabitTracker.UserInterface;

namespace HabitTracker.Habits;

public class Water : IHabit
{
    public int? Id { get; set; }
    public int Quantity { get; set; }
    public string? Type { get; set; }
    public string? Date { get; set; }
    
    public Water(int quantity = 0, string? date = null, int id = 0)
    {
        Id = id;
        Quantity = quantity;
        Date = date;
    }
    public void Print()
    {
        Console.WriteLine($"Id {Id}, Water, Quantity {Quantity}, Date {Date}");
    }

    public void SetParameters()
    {
        if (Quantity == 0)
        {
            Console.WriteLine("Enter water quantity:");
            Quantity = Input.ValidInt();
        }
        else
        {
            Console.WriteLine("Enter water quantity, press Space to skip:");
            var key = Console.ReadKey(intercept: true).Key;
            if (key == ConsoleKey.Spacebar)
            {
                // skip
            }
            else
            {
                Quantity = Input.ValidInt();
            }
        }

        if (Date == null)
        {
            Console.WriteLine("Enter Date (Format: MM/DD/YYYY) type 'now' for todays date:");
            Date = Input.ValidDate();
        }
        else
        {
            Console.WriteLine("Enter Date (Format: MM/DD/YYYY) type 'now' for todays date, press Space to skip:");
            var key = Console.ReadKey(intercept: true).Key;
            if (key == ConsoleKey.Spacebar)
            {
                // skip
            }
            else
            {
                Date = Input.ValidDate();
            }
        }
    }
}