namespace WebAPI.Dtos.WorkingHoures;

public class WorkingHoursDto
{
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan OpeningTime { get; set; }
    public TimeSpan ClosingTime { get; set; }
}
