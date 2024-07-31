namespace Application.UseCases.Queries.Play.Dtos;

public class GetPlayDto
{
    public int PlayId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TicketPrice { get; set; }
    public string Description { get; set; }
    public string TheaterName { get; set; }
    public string CompositionName { get; set; }
    public string CompositionDescription { get; set; }
    public string HeroesInformation { get; set; }
}
