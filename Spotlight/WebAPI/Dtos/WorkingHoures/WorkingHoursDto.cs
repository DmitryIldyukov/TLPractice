namespace WebAPI.Dtos.WorkingHoures;

public class WorkingHoursDto
{
    public DayOfWeek DayOfWeek { get; init; }
    public TimeSpan OpeningTime { get; init; }
    public TimeSpan ClosingTime { get; init; }
}
