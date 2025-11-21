namespace HabitTracker.UserInterface;

public class MainMenu(IMenu insertMenu, IMenu selectMenu, IMenu deleteMenu, IMenu updateMenu) : IMenu
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
        Console.WriteLine("1 - Insert Record");
        Console.WriteLine("2 - Update Record");
        Console.WriteLine("3 - Delete Record");
        Console.WriteLine("4 - View Records");
        Console.WriteLine("5 - Exit");
    }


    public void Options()
    {
        var input = Input.ValidInt();

        switch (input)
        {
            case 1:
                insertMenu.DoJob();
                break;
            case 2:
                updateMenu.DoJob();
                break;
            case 3:
                deleteMenu.DoJob();
                break;
            case 4:
                selectMenu.DoJob();
                break;
            case 5:
                Environment.Exit(1);
                break;
            default:
                Console.WriteLine("Invalid Input");
                Thread.Sleep(500);
                break;
        }
    }
}