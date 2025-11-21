using Microsoft.Data.Sqlite;

namespace HabitTracker;

public class Config
{
    private const string ConnectionString = "Data Source=habit-Tracker.db";

    public static SqliteConnection ConnectDb()
    {
        var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        return connection;
    }
    
}