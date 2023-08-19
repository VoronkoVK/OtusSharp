using OtusSharp.Console.Repositories;

namespace OtusSharp.Console.Views;

public class CategoriesView
{
    private readonly CategoriesRepository _repository = new();

    public void ShowCategories()
    {
        var categories = _repository.GetCategories();

        System.Console.WriteLine("\nCategories:");
        foreach (var category in categories)
        {
            System.Console.WriteLine(category);
        }

        System.Console.WriteLine("\nPress any key to continue...");
        System.Console.ReadKey();
    }

    public void AddCategory()
    {
        System.Console.Write("Enter Title: ");
        var title = System.Console.ReadLine();

        var categoryAdded = _repository.CreateCategory(title);
        
        System.Console.WriteLine(categoryAdded ? "Category successfully added." : "Error when adding category.");

    }
}
