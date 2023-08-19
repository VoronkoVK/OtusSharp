namespace OtusSharp.Console.Views;

public class MenuView
{
    private readonly UsersView _usersView = new();
    private readonly CategoriesView  _categoriesView = new();
    private readonly OffersView  _offersView = new();
    
    public void Show()
    {
        int command;
        
        do
        {
            System.Console.WriteLine();
            System.Console.WriteLine("   --- MENU ---    ");
            System.Console.WriteLine("1. Show users.");
            System.Console.WriteLine("2. Add user.");
            System.Console.WriteLine("3. Show categories.");
            System.Console.WriteLine("4. Add category.");
            System.Console.WriteLine("5. Show offers.");
            System.Console.WriteLine("6. Add offer.");
            System.Console.WriteLine("10. Exit.");

            try
            {
                command = SelectCommand();
            }
            catch (Exception e)
            {
                command = 0;
                System.Console.WriteLine("ERROR: " + e.Message);
                System.Console.WriteLine("\nPress any key to continue...");
                System.Console.ReadKey();
            }

        } while (command != 10);
    }

    private int SelectCommand()
    {
        System.Console.WriteLine("\nEnter command:");
        int.TryParse(System.Console.ReadLine(), out var command);

        switch (command)
        {
            case 1:
                _usersView.ShowUsers();
                break;
            case 2:
                _usersView.AddUser();
                break;
            case 3:
                _categoriesView.ShowCategories();
                break;
            case 4:
                _categoriesView.AddCategory();
                break;
            case 5:
                _offersView.ShowOffers();
                break;
            case 6:
                _offersView.AddOffer();
                break;
            case 10:
                System.Console.WriteLine("See you.");
                break;
            default:
                System.Console.WriteLine($"Invalid input. Try again.");
                break;
        }

        return command;
    }
}
