namespace Application.UseCases.Queries.Theater.Dtos;

public class GetTheaterDto
{
    public int TheaterId { get; init; }
    public string Name { get; init; }
    public string Address { get; init; }
    public DateTime FirstOpeningDate { get; init; }
    public string Description { get; init; }
    public string PhoneNumber { get; init; }
}
