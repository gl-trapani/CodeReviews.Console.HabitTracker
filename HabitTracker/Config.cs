using Microsoft.Data.Sqlite;

namespace HabitTracker;

public class Config
{
    private string _connectionString = @"Data Source=habit-Tracker.db";

    public SqliteConnection? ConnectDb()
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        return connection;
    }
    
}