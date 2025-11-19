// See https://aka.ms/new-console-template for more information

using HabitTracker.Habits;
using HabitTracker.Repositories;

namespace HabitTracker;


internal class Program
{
    public static void Main(string[] args)
    {
        Config config = new Config();

        var connection = config.ConnectDb();
        
        BaseRepo exerciseRepo = new ExerciseRepo(connection);
        exerciseRepo.Insert(new Exercise("blbla", 1));
        exerciseRepo.Select();
    }
}