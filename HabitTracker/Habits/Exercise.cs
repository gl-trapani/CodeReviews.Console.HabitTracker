namespace HabitTracker.Habits;

public class Exercise : IHabit
{
    private int Id;
    private string Date;
    public int Quantity { get; set; }
    public string Type { get; set; }
    public Exercise(string type, int quantity)
    {
        Type = type;
        Quantity = quantity;
    }


}