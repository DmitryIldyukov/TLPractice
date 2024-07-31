using Application.Common.CQRS.Query;
using Application.UseCases.Queries.WorkingHours.Dtos;

namespace Application.UseCases.Queries.WorkingHours.GetWorkingHoursOnDayOfWeek;

public class GetWorkingHoursOnDayOfWeekQuery : IQuery<GetWorkingHoursDto>
{
    public int TheaterId { get; init; }
    public DayOfWeek DayOfWeek { get; init; }
}
