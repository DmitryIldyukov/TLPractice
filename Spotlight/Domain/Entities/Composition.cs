namespace Domain.Entities;

public class Composition
{
    public int CompositionId { get; init; }
    public string Name { get; set; }
    public string HeroesInformation { get; set; }
    public string ShortDescription { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }

    public ICollection<Play> Plays { get; set; }

    public Composition( string name, string shortDescription, string heroesInformation, int authorId )
    {
        Name = name;
        ShortDescription = shortDescription;
        HeroesInformation = heroesInformation;
        AuthorId = authorId;
    }
}
