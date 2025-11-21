using HabitTracker.Repositories;

namespace HabitTracker.UserInterface;

public class DeleteMenu(IRepo exerciseRepo, IRepo waterRepo, IRepo homeworkRepo, IMenu habitMenu) : IMenu
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
        Console.WriteLine("Delete From:");
        habitMenu.Display();
    }

    public void Options()
    {
        var userInput = Console.ReadLine();

        if (userInput == null) return;
        HabitTypes? input = (HabitTypes)Enum.Parse(typeof(HabitTypes), userInput);

        switch (input)
        {
            case HabitTypes.Exercise:
                DeleteExercise();
                break;
            case HabitTypes.Water:
                DeleteWater();
                break;
            case HabitTypes.Homework:
                DeleteHomework();
                break;
            default:
                Console.WriteLine("Invalid Input");
                Thread.Sleep(500);
                break;
        }
    }

    private void DeleteWater()
    {
        var waters = waterRepo.Select();
        foreach (var water in waters)
        {
            water.Print();
        }

        Console.WriteLine("1 - Delete All Records");
        Console.WriteLine("2 - Delete By Id");

        var input = Input.ValidInt();

        switch (input)
        {
            case 1:
                waterRepo.Delete();
                break;
            case 2:
                Console.WriteLine("Enter Id to Delete");
                var id = Input.ValidInt();
                waterRepo.Delete(id);
                break;
            default:
                Console.WriteLine("Invalid Input");
                Thread.Sleep(500);
                break;
        }
    }

    private void DeleteExercise()
    {
        var exercises = exerciseRepo.Select();
        foreach (var exercise in exercises)
        {
            exercise.Print();
        }

        Console.WriteLine("1 - Delete All Records");
        Console.WriteLine("2 - Delete By Id");

        var input = Input.ValidInt();

        switch (input)
        {
            case 1:
                exerciseRepo.Delete();
                break;
            case 2:
                Console.WriteLine("Enter Id to Delete");
                var id = Input.ValidInt();
                exerciseRepo.Delete(id);
                break;
        }
    }

    private void DeleteHomework()
    {
        var exercises = homeworkRepo.Select();
        foreach (var exercise in exercises)
        {
            exercise.Print();
        }

        Console.WriteLine("1 - Delete All Records");
        Console.WriteLine("2 - Delete By Id");

        var input = Input.ValidInt();

        switch (input)
        {
            case 1:
                homeworkRepo.Delete();
                break;
            case 2:
                Console.WriteLine("Enter Id to Delete");
                var id = Input.ValidInt();
                homeworkRepo.Delete(id);
                break;
        }
    }
}