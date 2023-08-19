namespace OtusSharp.Console.Models;

public class Offer
{
    public int Id { get; set; }

    public required int AuthorId { get; set; }
    public required int CategoryId { get; set; }

    public required string Title { get; set; }
    public decimal Cost { get; set; }
    
    public override string ToString()
    {
        return $"Offer: Id={Id}, AuthorId={AuthorId}, CategoryId={CategoryId}, Title={Title}, Cost={Cost}";
    }
}
