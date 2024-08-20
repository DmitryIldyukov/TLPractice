namespace Domain.Entities;

public class Author
{
    public int AuthorId { get; init; }
    public string Name { get; set; }
    public DateTime Birthday { get; init; }

    public ICollection<Composition> Compositions { get; init; } = new HashSet<Composition>();

    public Author( string name, DateTime birthday )
    {
        Name = name;
        Birthday = birthday;
    }
}
