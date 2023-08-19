using OtusSharp.Console.Repositories;

namespace OtusSharp.Console.Views;

public class OffersView
{
    private readonly OffersRepository _repository = new();

    public void ShowOffers()
    {
        var offers = _repository.GetOffers();

        System.Console.WriteLine("\nOffers:");
        foreach (var offer in offers)
        {
            System.Console.WriteLine(offer);
        }

        System.Console.WriteLine("\nPress any key to continue...");
        System.Console.ReadKey();
    }

    public void AddOffer()
    {
        System.Console.Write("Enter AuthorId: ");
        var authorId = int.Parse(System.Console.ReadLine());
        System.Console.Write("Enter CategoryId: ");
        var categoryId = int.Parse(System.Console.ReadLine());
        System.Console.Write("Enter Title: ");
        var title = System.Console.ReadLine();
        System.Console.Write("Enter Cost: ");
        var cost = decimal.Parse(System.Console.ReadLine());

        var offerAdded = _repository.CreateOffer(authorId, categoryId, title, cost);
        
        System.Console.WriteLine(offerAdded ? "Offer successfully added." : "Error when adding offer.");
        
        System.Console.WriteLine("\nPress any key to continue...");
        System.Console.ReadKey();
    }
}
