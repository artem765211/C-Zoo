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
    public List<Animal> GetAllAnimals()
    {
        var animals = new List<Animal>();
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT Name,Type,Energy FROM Animals";

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            string name = reader.GetString(0);
            string type = reader.GetString(1);
            int energy = reader.GetInt32(2);

            Animal animal;

            if(type == "Lion")
            {
                animal = new Lion(name);
            }
            else if (type =="Dog")
            {
                animal = new Dog(name);
            }

            else { continue; }

            animal.Energy = energy;

            animals.Add(animal);

        }
        return animals;
    }
}