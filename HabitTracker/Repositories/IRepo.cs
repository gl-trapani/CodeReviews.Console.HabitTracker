using HabitTracker.Habits;

namespace HabitTracker.Repositories;

public interface IRepo
{
    public void CreateTable();

    public void Insert(IHabit habit);

    public List<IHabit> Select();

    public void Update(IHabit habit);
    
    public void Delete(int id);
    
    public void Delete();
}