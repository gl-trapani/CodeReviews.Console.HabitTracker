using HabitTracker.Habits;
using Microsoft.Data.Sqlite;

namespace HabitTracker.Repositories;

public class WaterRepo : IRepo
{
    private readonly SqliteConnection _connection;

    public WaterRepo(SqliteConnection connection)
    {
        this._connection = connection;
        CreateTable();
    }

    public void CreateTable()
    {
        var tableCmd = _connection.CreateCommand();
        tableCmd.CommandText =
            """
            CREATE TABLE IF NOT EXISTS habit_water(
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        date event_date TEXT CHECK (date LIKE '__/__/____'),
                        quantity SMALLINT NOT NULL
                        )
            """;
        tableCmd.ExecuteNonQuery();
    }

    public void Insert(IHabit habit)
    {
        var tableCmd = _connection.CreateCommand();
        tableCmd.CommandText =
            """
            INSERT INTO habit_water(date, quantity) 
            VALUES(@date, @quantity)
            """;
        tableCmd.Parameters.AddWithValue("@date", habit.Date);
        tableCmd.Parameters.AddWithValue("@quantity", habit.Quantity);
        tableCmd.ExecuteNonQuery();
        Console.WriteLine($"New Water Created Successfully. Returning...");
        Thread.Sleep(2000);
    }

    public List<IHabit> Select()
    {
        var waters = new List<IHabit>();

        var tableCmd = _connection.CreateCommand();
        tableCmd.CommandText =
            "SELECT * FROM habit_water";

        var reader = tableCmd.ExecuteReader();
        while (reader.Read())
        {
            int.TryParse(reader["id"].ToString(), out var id);
            var date = reader["date"].ToString();
            int.TryParse(reader["quantity"].ToString(), out var quantity);

            waters.Add(new Water(quantity, date, id));
        }

        return waters;
    }

    public void Update(IHabit habit)
    {
        var tableCmd = _connection.CreateCommand();
        tableCmd.CommandText = "UPDATE habit_water SET date = @date, quantity = @quantity WHERE id = @id";
        tableCmd.Parameters.AddWithValue("@id", habit.Id);
        tableCmd.Parameters.AddWithValue("@date", habit.Date);
        tableCmd.Parameters.AddWithValue("@quantity", habit.Quantity);
        tableCmd.ExecuteNonQuery();
    }

    public void Delete()
    {
        var tableCmd = _connection.CreateCommand();
        tableCmd.CommandText = "DELETE FROM habit_water";
        tableCmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        var tableCmd = _connection.CreateCommand();
        tableCmd.CommandText = "DELETE FROM habit_water WHERE id = @id";
        tableCmd.Parameters.AddWithValue("@id", id);
        tableCmd.ExecuteNonQuery();
    }
}