namespace HabitTracker.Habits;

public class Exercise : IHabit
{
    private int Id;
    public int Quantity { get; set; }
    public string? Type { get; set; }
    public string? Date { get; set; }

    public Exercise(string type, int quantity, string? date)
    {
        Type = type;
        Quantity = quantity;

        Date = date == "now" ? DateTime.Now.ToShortDateString() : date;
    }
}