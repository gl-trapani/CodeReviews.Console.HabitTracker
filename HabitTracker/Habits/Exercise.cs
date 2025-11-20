namespace HabitTracker.Habits;

public class Exercise : IHabit
{
    private int? Id { get; set; }
    public int Quantity { get; set; }
    public string? Type { get; set; }
    public string? Date { get; set; }

    public Exercise(string type, int quantity, string? date, int id = 0)
    {
        Id = id;
        Type = type;
        Quantity = quantity;

        Date = date == "now" ? DateTime.Now.ToShortDateString() : date;
    }

    public void Print()
    {
        Console.WriteLine($"Id {Id}, Exercise {Type}, Quantity {Quantity}, Date {Date}");
    }
}