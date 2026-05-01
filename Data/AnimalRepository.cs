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
            id INTEGER PRIMARY KEY AUTOINCREMENT,
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

        var command2 = connection.CreateCommand();
        command2.CommandText = """
            SELECT last_insert_rowid()
            """;
        int last_insert_rowid = Convert.ToInt32(command2.ExecuteScalar());
        animal.id = last_insert_rowid;
    }
    public void RemoveAnimal(int id)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
            """
            DELETE FROM Animals
            WHERE id = @id
            """;
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
    }
    public List<Animal> GetAllAnimals()
    {
        var animals = new List<Animal>();
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT Id,Name,Type,Energy FROM Animals";

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            string type = reader.GetString(2);
            int energy = reader.GetInt32(3);

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

            animal.id = id;
            animal.Energy = energy;

            animals.Add(animal);

        }
        return animals;
    }
}