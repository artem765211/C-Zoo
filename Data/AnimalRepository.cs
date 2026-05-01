using GitHub_project.Models;
using Microsoft.Data.Sqlite;

namespace GitHub_project.Data;

public class AnimalRepository
{
    private const string ConnectionString = "Data Source=zoo.db";

    public void Initialize()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
        """
        CREATE TABLE IF NOT EXISTS Animals (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL,
            Type TEXT NOT NULL,
            Energy INTEGER NOT NULL
        );
        """;

        command.ExecuteNonQuery();
    }

    public void AddAnimal(Animal animal)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
        """
        INSERT INTO Animals (Name, Type, Energy)
        VALUES ($name, $type, $energy);
        """;

        command.Parameters.AddWithValue("$name", animal.Name);
        command.Parameters.AddWithValue("$type", animal.Type());
        command.Parameters.AddWithValue("$energy", animal.Energy);

        command.ExecuteNonQuery();
    }
}