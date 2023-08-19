using OtusSharp.Console.Repositories;

namespace OtusSharp.Console.Views;

public class UsersView
{
    private readonly UsersRepository _repository = new();

    public void ShowUsers()
    {
        var users = _repository.GetUsers();

        System.Console.WriteLine("\nUsers:");
        foreach (var user in users)
        {
            System.Console.WriteLine(user);
        }

        System.Console.WriteLine("\nPress any key to continue...");
        System.Console.ReadKey();
    }

    public void AddUser()
    {
        System.Console.Write("Enter Name: ");
        var name = System.Console.ReadLine();
        System.Console.Write("Enter Email: ");
        var email = System.Console.ReadLine();

        var userAdded = _repository.CreateUser(name!, email!);

        System.Console.WriteLine(userAdded ? "User successfully added." : "Error when adding user.");
        
        System.Console.WriteLine("\nPress any key to continue...");
        System.Console.ReadKey();
    }
}
