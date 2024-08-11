namespace WebAPI.Dtos.Play;

public class PlayDto
{
    public string Name { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public decimal TicketPrice { get; init; }
    public string Description { get; init; }
    public int TheaterId { get; init; }
    public int CompositionId { get; init; }
}
