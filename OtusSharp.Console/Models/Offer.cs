namespace OtusSharp.Console.Models;

public class Offer
{
    public int Id { get; set; }

    public required User Author { get; set; }
    public required Category Category { get; set; }

    public required string Title { get; set; }
    public string? Description { get; set; }
    public float Cost { get; set; }
}
