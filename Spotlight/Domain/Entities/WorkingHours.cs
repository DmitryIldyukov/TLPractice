namespace Domain.Entities;

public class WorkingHours
{
    public int WorkingHoursId { get; init; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan OpeningTime { get; set; }
    public TimeSpan ClosingTime { get; set; }

    public int TheaterId { get; set; }
    public Theater Theater { get; set; }

    public WorkingHours( DayOfWeek dayOfWeek, TimeSpan openingTime, TimeSpan closingTime, int theaterId )
    {
        DayOfWeek = dayOfWeek;
        OpeningTime = openingTime;
        ClosingTime = closingTime;
        TheaterId = theaterId;
    }
}
