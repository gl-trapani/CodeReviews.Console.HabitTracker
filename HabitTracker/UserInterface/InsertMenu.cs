using HabitTracker.Habits;
using HabitTracker.Repositories;

namespace HabitTracker.UserInterface;

public class InsertMenu(IRepo exerciseRepo, IRepo waterRepo, IRepo homeworkRepo, IMenu habitMenu) : IMenu
{
    public void DoJob()
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
        habitMenu.Display();
    }

    private void Options()
    {
        var userInput = Console.ReadLine();

        if (userInput == null) return;
        
        HabitTypes? input = (HabitTypes)Enum.Parse(typeof(HabitTypes), userInput);

        switch (input)
        {
            case HabitTypes.Exercise:
                var exercise = new Exercise();
                exercise.SetParameters();
                exerciseRepo.Insert(exercise);
                break;
            case HabitTypes.Water:
                var water = new Water();
                water.SetParameters();
                waterRepo.Insert(water);
                break;
            case HabitTypes.Homework:
                var homework = new Homework();
                homework.SetParameters();
                homeworkRepo.Insert(homework);
                break;
            default:
                Console.WriteLine("Invalid input");
                Console.WriteLine(500);
                break;
        }
    }
}