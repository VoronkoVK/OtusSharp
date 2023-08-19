using Npgsql;
using OtusSharp.Console.Config;
using OtusSharp.Console.Models;

namespace OtusSharp.Console.Repositories;

public class CategoriesRepository
{
    public IReadOnlyList<Category> GetCategories()
    {
        var categories = new List<Category>();

        try
        {
            categories = GetCategoriesFromDb();
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
        }

        return categories;
    }
    
    public bool InsertCategory(string title)
    {
        try
        {
            var affectedRowsCount = InsertCategoriesToDb(title);
            return affectedRowsCount > 0;
        }
        catch (PostgresException e)
        {
            System.Console.WriteLine("ERROR: " + e.MessageText);
        }

        return false;
    }

    private List<Category> GetCategoriesFromDb()
    {
        using var connection = new NpgsqlConnection(DbContextConfig.ConnectionString);
        connection.Open();

        var sql = "SELECT * FROM categories";

        using var cmd = new NpgsqlCommand(sql, connection);
        var reader = cmd.ExecuteReader();

        var categories = new List<Category>();
        while (reader.Read())
        {
            var id = reader.GetInt32(0);
            var title = reader.GetString(1);
            var category = new Category
            {
                Id = id,
                Title = title,
            };
            categories.Add(category);
        }

        return categories;
    }

    private int InsertCategoriesToDb(string title)
    {
        using var connection = new NpgsqlConnection(DbContextConfig.ConnectionString);
        connection.Open();

        var sql = "INSERT INTO categories(title) VALUES (:title)";

        using var cmd = new NpgsqlCommand(sql, connection);
        var parameters = cmd.Parameters;
        parameters.Add(new NpgsqlParameter("title", title));

        return cmd.ExecuteNonQuery();
    }
}
