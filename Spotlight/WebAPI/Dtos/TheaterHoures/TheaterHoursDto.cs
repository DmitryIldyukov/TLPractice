namespace WebAPI.Dtos.TheaterHoures;

public class TheaterHoursDto
{
    public DayOfWeek DayOfWeek { get; init; }
    public TimeSpan OpeningTime { get; init; }
    public TimeSpan ClosingTime { get; init; }
}
