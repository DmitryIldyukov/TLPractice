namespace Domain.Entities;

public class Author
{
    public int AuthorId { get; init; }
    public string Name { get; private set; }
    public DateOnly Birthday { get; init; }

    public ICollection<Composition> Compositions { get; init; } = new HashSet<Composition>();
}
