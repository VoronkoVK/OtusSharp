namespace OtusSharp.Console.Models;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }

    public override string ToString()
    {
        return $"User: Id={Id}, Name={Name}, Email={Email}";
    }
}
