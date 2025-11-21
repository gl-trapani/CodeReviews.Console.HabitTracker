namespace HabitTracker.UserInterface;

public class HabitMenu : IMenu
{
    public void DoJob()
    {
        Display();
    }

    public void Display()
    {
        foreach (HabitTypes type in Enum.GetValues(typeof(HabitTypes)))
        {
            Console.WriteLine($"{(int)type} - {type}");
        }
    }
}