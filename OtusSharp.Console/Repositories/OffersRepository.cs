using Npgsql;
using OtusSharp.Console.Config;
using OtusSharp.Console.Models;

namespace OtusSharp.Console.Repositories;

public class OffersRepository
{
    public IReadOnlyList<Offer> GetOffers()
    {
        var offers = new List<Offer>();

        try
        {
            offers = GetOffersFromDb();
        }
        catch (PostgresException e)
        {
            System.Console.WriteLine("ERROR: " + e.MessageText);
        }

        return offers.AsReadOnly();
    }

    public bool InsertOffer(int authorId, int categoryId, string title, decimal cost)
    {
        try
        {
            var affectedRowsCount = InsertOfferToDb(authorId, categoryId, title, cost);
            return affectedRowsCount > 0;
        }
        catch (PostgresException e)
        {
            System.Console.WriteLine("ERROR: " + e.MessageText);
        }

        return false;
    }

    private List<Offer> GetOffersFromDb()
    {
        using var connection = new NpgsqlConnection(DbContextConfig.ConnectionString);
        connection.Open();

        var sql = "SELECT * FROM offers";

        using var cmd = new NpgsqlCommand(sql, connection);
        var reader = cmd.ExecuteReader();

        var offers = new List<Offer>();
        while (reader.Read())
        {
            var id = reader.GetInt32(0);
            var authorId = reader.GetInt32(1);
            var categoryId = reader.GetInt32(2);
            var title = reader.GetString(3);
            var cost = reader.GetDecimal(4);
            var offer = new Offer
            {
                Id = id,
                AuthorId = authorId,
                CategoryId = categoryId,
                Title = title,
                Cost = cost
            };
            offers.Add(offer);
        }

        return offers;
    }

    private int InsertOfferToDb(int authorId, int categoryId, string title, decimal cost)
    {
        using var connection = new NpgsqlConnection(DbContextConfig.ConnectionString);
        connection.Open();

        var sql =
            "INSERT INTO offers(author_id, category_id, title, cost) VALUES (:author_id, :category_id, :title, :cost)";

        using var cmd = new NpgsqlCommand(sql, connection);
        var parameters = cmd.Parameters;
        parameters.Add(new NpgsqlParameter("author_id", authorId));
        parameters.Add(new NpgsqlParameter("category_id", categoryId));
        parameters.Add(new NpgsqlParameter("title", title));
        parameters.Add(new NpgsqlParameter("cost", cost));

        return cmd.ExecuteNonQuery();
    }
}
