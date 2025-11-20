using HabitTracker.Habits;
using HabitTracker.Repositories;

namespace HabitTracker.UserInterface;

public class InsertMenu (BaseRepo exerciseRepo)
{
    private BaseRepo _exerciseRepo = exerciseRepo;

    public void DoInsert()
    {
        Display();
        Options();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("Habit Tracker");
        Console.WriteLine();
        Console.WriteLine("Habit to insert:");
        Console.WriteLine("1 - Exercise");
    }

    public void Options()
    {
        int.TryParse(Console.ReadLine(),out int input);
        
        switch (input)
        {
            case 1:
                //todo make method
                Console.WriteLine("Enter exercise Name:");
                string? type = Console.ReadLine();
                Console.WriteLine("Enter exercise Quantity:");
                int quantity = Input.ValidInt();
                Console.WriteLine("Enter Date (Format: MM/DD/YYYY) type 'now' for todays date:");
                string date = Input.ValidDate();
                _exerciseRepo.Insert(new Exercise(type, quantity, date));
                break;
        }
    }
}