using HabitTracker.Repositories;

namespace HabitTracker.UserInterface;

public class MainMenu(BaseRepo exerciseRepo)
{
    InsertMenu insertMenu = new(exerciseRepo);

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("Habit Tracker");
        Console.WriteLine();
        Console.WriteLine("1 - Insert Record");
        Console.WriteLine("2 - Update Record");
        Console.WriteLine("3 - Delete Record");
        Console.WriteLine("4 - View Records");
    }

    public void Options()
    {
        int input = Input.ValidInt();
        
        switch (input)
        {
            case 1:
                insertMenu.DoInsert();
                break;
        }
    }
}