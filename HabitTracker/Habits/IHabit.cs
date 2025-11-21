namespace HabitTracker.Habits;

public interface IHabit
{
    int? Id { get; set; }
    int Quantity { get; set; }
    string? Type { get; set; }
    string Date { get; set; }
    public void Print();
    public void SetParameters();
}