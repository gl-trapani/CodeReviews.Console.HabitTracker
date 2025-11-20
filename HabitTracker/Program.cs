// See https://aka.ms/new-console-template for more information

using HabitTracker.Repositories;
using HabitTracker.UserInterface;

namespace HabitTracker;

internal class Program
{
    public static void Main(string[] args)
    {
        var config = new Config();

        var connection = config.ConnectDb();


        BaseRepo exerciseRepo = new ExerciseRepo(connection);
        
        var mainMenu = new MainMenu(exerciseRepo);

        while (true)
        {
            mainMenu.Display();
            mainMenu.Options();
        }
    }
}