using HabitTracker.Repositories;

namespace HabitTracker.UserInterface;

public class SelectMenu(IRepo exerciseRepo, IRepo waterRepo, IRepo homeworkRepo, IMenu habitMenu) : IMenu
{
    public void DoJob()
    {
        Display();
        Options();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("1 - Display all records");
        Console.WriteLine("2 - Display by habits");
    }

    private void Options()
    {
        var input = Input.ValidInt();

        switch (input)
        {
            case 1:
                PrintRecords(exerciseRepo);
                PrintRecords(waterRepo);
                PrintRecords(homeworkRepo);
                Console.WriteLine("Press any key to return to main menu");
                Console.ReadKey();
                break;
            case 2:
                Console.WriteLine("Choose option:");
                habitMenu.Display();
                SelectHabit();
                Console.WriteLine("Press any key to return to main menu");
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("Invalid Input");
                Thread.Sleep(500);
                break;
        }
    }

    private void SelectHabit()
    {
        var userInput = Console.ReadLine();

        if (userInput == null) return;
        HabitTypes? input = (HabitTypes)Enum.Parse(typeof(HabitTypes), userInput);

        switch (input)
        {
            case HabitTypes.Exercise:
                PrintRecords(exerciseRepo);
                break;
            case HabitTypes.Water:
                PrintRecords(waterRepo);
                break;
            case HabitTypes.Homework:
                PrintRecords(homeworkRepo);
                break;
            default:
                Console.WriteLine("Invalid Input");
                Thread.Sleep(500);
                break;
        }
    }

    private void PrintRecords(IRepo repo)
    {
        var habits = repo.Select();
        foreach (var habit in habits)
        {
            habit.Print();
        }
    }
}