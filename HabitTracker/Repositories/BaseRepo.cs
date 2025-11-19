using HabitTracker.Habits;

namespace HabitTracker.Repositories;

public abstract class BaseRepo
{
    public abstract void CreateTable();

    public abstract void Insert(IHabit habit);

    public abstract void Select();

    public abstract void Update();
    
    public abstract void Delete();
}