using Npgsql;
using OtusSharp.Console.Config;
using OtusSharp.Console.Models;

namespace OtusSharp.Console.Repositories;

public class UsersRepository
{
    public IReadOnlyList<User> GetUsers()
    {
        var users = new List<User>();

        try
        {
            users = GetUsersFromDb();
        }
        catch (PostgresException e)
        {
            System.Console.WriteLine("ERROR: " + e.MessageText);
        }

        return users.AsReadOnly();
    }
    
    public bool CreateUser(string name, string email)
    {
        try
        {
            var affectedRowsCount = InsertUserToDb(name, email);
            return affectedRowsCount > 0;
        }
        catch (PostgresException e)
        {
            System.Console.WriteLine("ERROR: " + e.MessageText);
        }

        return false;
    }

    private List<User> GetUsersFromDb()
    {
        using var connection = new NpgsqlConnection(DbContextConfig.ConnectionString);
        connection.Open();

        var sql = "SELECT * FROM users";

        using var cmd = new NpgsqlCommand(sql, connection);
        var reader = cmd.ExecuteReader();

        var users = new List<User>();
        while (reader.Read())
        {
            var id = reader.GetInt32(0);
            var name = reader.GetString(1);
            var email = reader.GetString(2);
            var user = new User
            {
                Id = id,
                Name = name,
                Email = email
            };
            users.Add(user);
        }

        return users;
    }

    private int InsertUserToDb(string name, string email)
    {
        using var connection = new NpgsqlConnection(DbContextConfig.ConnectionString);
        connection.Open();

        var sql = "INSERT INTO users(name, email) VALUES (:name, :email)";

        using var cmd = new NpgsqlCommand(sql, connection);
        var parameters = cmd.Parameters;
        parameters.Add(new NpgsqlParameter("name", name));
        parameters.Add(new NpgsqlParameter("email", email));

        return cmd.ExecuteNonQuery();
    }
}
