using HabitTracker.Habits;
using HabitTracker.Repositories;

namespace HabitTracker.UserInterface;

public class SelectMenu(BaseRepo exerciseRepo)
{
    private BaseRepo _exerciseRepo = exerciseRepo;

    public void DoSelect()
    {
        Display();
        Options();
    }

    private void Display()
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
                var exercises = _exerciseRepo.Select();
                foreach (var exercise in exercises)
                {
                    exercise.Print();
                }

                Console.WriteLine("Press any key to return to main menu");
                Console.ReadKey();
                break;
        }
    }
}