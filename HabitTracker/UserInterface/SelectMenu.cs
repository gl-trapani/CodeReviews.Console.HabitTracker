using HabitTracker.Repositories;
using Microsoft.Extensions.Options;

namespace HabitTracker.UserInterface;

public class SelectMenu (BaseRepo exerciseRepo)
{
    private BaseRepo _exerciseRepo = exerciseRepo;

    public void DoSelect()
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

    public void Options()
    {
        
    }
    
}