using HabitTracker.Habits;
using Microsoft.Data.Sqlite;

namespace HabitTracker.Repositories;

public class HomeworkRepo : IRepo
{
    private readonly SqliteConnection _connection;

    public HomeworkRepo(SqliteConnection connection)
    {
        _connection = connection;
        CreateTable();
    }

    public void CreateTable()
    {
        var tableCmd = _connection.CreateCommand();
        tableCmd.CommandText =
            """
            CREATE TABLE IF NOT EXISTS habit_homework(
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        date event_date TEXT CHECK (date LIKE '__/__/____'),
                        homework_type VARCHAR(255),
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
            INSERT INTO habit_homework(date, homework_type,quantity) 
            VALUES(@date, @homework_type, @quantity)
            """;
        tableCmd.Parameters.AddWithValue("@date", habit.Date);
        tableCmd.Parameters.AddWithValue("@quantity", habit.Quantity);
        tableCmd.Parameters.AddWithValue("@homework_type", habit.Type);
        tableCmd.ExecuteNonQuery();
        Console.WriteLine($"New Homework Created Successfully. Returning...");
        Thread.Sleep(2000);
    }

    public List<IHabit> Select()
    {
        var exercises = new List<IHabit>();

        var tableCmd = _connection.CreateCommand();
        tableCmd.CommandText =
            "SELECT * FROM habit_homework";

        var reader = tableCmd.ExecuteReader();
        while (reader.Read())
        {
            int.TryParse(reader["id"].ToString(), out var id);
            var date = reader["date"].ToString();
            var type = reader["homework_type"].ToString();
            int.TryParse(reader["quantity"].ToString(), out var quantity);

            exercises.Add(new Homework(type, quantity, date, id));
        }

        return exercises;
    }

    public void Update(IHabit habit)
    {
        var tableCmd = _connection.CreateCommand();
        tableCmd.CommandText =
            "UPDATE habit_homework SET homework_type = @type, date = @date, quantity = @quantity WHERE id = @id";
        tableCmd.Parameters.AddWithValue("@id", habit.Id);
        tableCmd.Parameters.AddWithValue("@date", habit.Date);
        tableCmd.Parameters.AddWithValue("@type", habit.Type);
        tableCmd.Parameters.AddWithValue("@quantity", habit.Quantity);
        tableCmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        var tableCmd = _connection.CreateCommand();
        tableCmd.CommandText =
            @"DELETE FROM habit_homework WHERE id = @id; UPDATE sqlite_sequence SET seq = (SELECT MAX(id) FROM habit_homework) WHERE name='habit_homework'";
        tableCmd.Parameters.AddWithValue("@id", id);
        tableCmd.ExecuteNonQuery();
    }

    public void Delete()
    {
        var tableCmd = _connection.CreateCommand();
        tableCmd.CommandText =
            @"DELETE FROM habit_homework; UPDATE sqlite_sequence SET seq = (SELECT MAX(id) FROM habit_homework) WHERE name='habit_homework'";
        tableCmd.ExecuteNonQuery();
    }
}