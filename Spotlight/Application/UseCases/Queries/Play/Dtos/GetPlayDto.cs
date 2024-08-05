namespace Application.UseCases.Queries.Play.Dtos;

public class GetPlayDto
{
    public int PlayId { get; init; }
    public string Name { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public decimal TicketPrice { get; init; }
    public string Description { get; init; }
    public string TheaterName { get; init; }
    public string CompositionName { get; init; }
    public string CompositionDescription { get; init; }
    public string HeroesInformation { get; init; }
}
