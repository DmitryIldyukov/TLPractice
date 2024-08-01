namespace Application.UseCases.Queries.WorkingHours.Dtos;

public class GetWorkingHoursDto
{
    public int WorkingHoursId { get; init; }
    public int TheaterId { get; init; }
    public DayOfWeek DayOfWeek { get; init; }
    public TimeSpan OpeningTime { get; init; }
    public TimeSpan ClosingTime { get; init; }
}
