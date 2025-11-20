using HabitTracker.Habits;
using Microsoft.Data.Sqlite;

namespace HabitTracker.Repositories;

public class ExerciseRepo : BaseRepo
{
    private SqliteConnection connection;

    public ExerciseRepo(SqliteConnection connection)
    {
        this.connection = connection;
        CreateTable();
    }

    public override void CreateTable()
    {
        var tableCmd = connection.CreateCommand();
        tableCmd.CommandText =
            """
            CREATE TABLE IF NOT EXISTS habit_exercise(
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        date event_date TEXT CHECK (date LIKE '__/__/____'),
                        exercise_type VARCHAR(255),
                        quantity SMALLINT NOT NULL
                        )
            """;
        tableCmd.ExecuteNonQuery();
    }

    public override void Insert(IHabit exercise)
    {
        var tableCmd = connection.CreateCommand();
        tableCmd.CommandText =
            """
            INSERT INTO habit_exercise(date, exercise_type,quantity) 
            VALUES(@date, @exercise_type, @quantity)
            """;
        tableCmd.Parameters.AddWithValue("@date", exercise.Date);
        tableCmd.Parameters.AddWithValue("@quantity", exercise.Quantity);
        tableCmd.Parameters.AddWithValue("@exercise_type", exercise.Type);
        tableCmd.ExecuteNonQuery();
        Console.WriteLine($"New Exercise Created Successfully");
    }

    public override void Select()
    {
       var tableCmd = connection.CreateCommand();
       tableCmd.CommandText =
           """
           SELECT * FROM habit_exercise
           """;
       var reader = tableCmd.ExecuteReader();
       while (reader.Read())
       {
           var date = reader["date"].ToString();
           var exerciseType = reader["exercise_type"].ToString();
           var quantity = reader["quantity"].ToString();
           
           Console.WriteLine($"{date} {exerciseType} {quantity}");
       }
    }

    public override void Update()
    {
        throw new NotImplementedException();
    }

    public override void Delete()
    {
        throw new NotImplementedException();
    }
}