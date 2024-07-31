namespace Application.UseCases.Queries.WorkingHours.Dtos;

public class GetWorkingHoursDto
{
    public int WorkingHoursId { get; init; }
    public int TheaterId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan OpeningTime { get; set; }
    public TimeSpan ClosingTime { get; set; }
}
