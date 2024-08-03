namespace Application.UseCases.Queries.TheaterHours.Dtos;

public class GetTheaterHoursDto
{
    public int TheaterHoursId { get; init; }
    public int TheaterId { get; init; }
    public DayOfWeek DayOfWeek { get; init; }
    public TimeSpan OpeningTime { get; init; }
    public TimeSpan ClosingTime { get; init; }
}
