using HabitTracker.Repositories;

namespace HabitTracker.UserInterface;

public class UpdateMenu(IRepo exerciseRepo, IRepo waterRepo, IRepo homeworkRepo, IMenu habitMenu) : IMenu
{
    public void DoJob()
    {
        Display();
        Option();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("Habit Tracker");
        Console.WriteLine();
        Console.WriteLine("Update:");
        habitMenu.Display();
    }

    private void Option()
    {
        var userInput = Console.ReadLine();

        HabitTypes? input = (HabitTypes)Enum.Parse(typeof(HabitTypes), userInput);

        switch (input)
        {
            case HabitTypes.Exercise:
                UpdateExercise();
                break;
            case HabitTypes.Water:
                UpdateWater();
                break;
            case HabitTypes.Homework:
                UpdateHomework();
                break;
            default:
                Console.WriteLine("Invalid Input");
                Thread.Sleep(500);
                break;
        }
    }

    private void UpdateWater()
    {
        var waters = waterRepo.Select();
        foreach (var water in waters)
        {
            water.Print();
        }

        Console.WriteLine("Select Id: ");
        var input = Input.ValidInt();

        var idFound = false;

        foreach (var water in waters)
        {
            if (water.Id == input)
            {
                water.SetParameters();
                waterRepo.Update(water);
                idFound = true;
            }

            if (idFound) return;
            Console.WriteLine("Id not found. Returning...");
            Thread.Sleep(1000);
        }
    }

    private void UpdateExercise()
    {
        var exercises = exerciseRepo.Select();
        foreach (var exercise in exercises)
        {
            exercise.Print();
        }

        Console.WriteLine("Select Id: ");
        var input = Input.ValidInt();

        var idFound = false;

        foreach (var exercise in exercises)
        {
            if (exercise.Id != input) continue;
            exercise.SetParameters();
            exerciseRepo.Update(exercise);
            idFound = true;
        }

        if (idFound) return;
        Console.WriteLine("Id not found. Returning...");
        Thread.Sleep(1000);
    }
    
    private void UpdateHomework()
    {
        var homeworks = homeworkRepo.Select();
        foreach (var homework in homeworks)
        {
            homework.Print();
        }

        Console.WriteLine("Select Id: ");
        var input = Input.ValidInt();

        var idFound = false;

        foreach (var homework in homeworks)
        {
            if (homework.Id != input) continue;
            homework.SetParameters();
            exerciseRepo.Update(homework);
            idFound = true;
        }

        if (idFound) return;
        Console.WriteLine("Id not found. Returning...");
        Thread.Sleep(1000);
    }
}