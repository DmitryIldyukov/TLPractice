namespace Domain.Entities;

public class TheaterHours
{
    public int TheaterHoursId { get; init; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan OpeningTime { get; set; }
    public TimeSpan ClosingTime { get; set; }

    public int TheaterId { get; set; }
    public Theater Theater { get; set; }

    public TheaterHours( DayOfWeek dayOfWeek, TimeSpan openingTime, TimeSpan closingTime, int theaterId )
    {
        DayOfWeek = dayOfWeek;
        OpeningTime = openingTime;
        ClosingTime = closingTime;
        TheaterId = theaterId;
    }
}
