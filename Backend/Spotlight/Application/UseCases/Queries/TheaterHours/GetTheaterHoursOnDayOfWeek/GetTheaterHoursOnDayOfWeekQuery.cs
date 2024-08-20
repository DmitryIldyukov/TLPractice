using Application.Common.CQRS.Query;
using Application.UseCases.Queries.TheaterHours.Dtos;

namespace Application.UseCases.Queries.TheaterHours.GetTheaterHoursOnDayOfWeek;

public class GetTheaterHoursOnDayOfWeekQuery : IQuery<GetTheaterHoursDto>
{
    public int TheaterId { get; init; }
    public DayOfWeek DayOfWeek { get; init; }
}
