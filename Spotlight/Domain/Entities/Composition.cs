namespace Domain.Entities;

public class Composition
{
    public int CompositionId { get; init; }
    public string Name { get; private set; }
    public string HeroesInformation { get; private set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }

    public ICollection<Play> Plays { get; set; }
}
