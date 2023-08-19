namespace OtusSharp.Console.Models;

public class Category
{
    public int Id { get; set; }
    public required string Title { get; set; }

    public override string ToString()
    {
        return $"Category: Id={Id}, Title={Title}";
    }
}
