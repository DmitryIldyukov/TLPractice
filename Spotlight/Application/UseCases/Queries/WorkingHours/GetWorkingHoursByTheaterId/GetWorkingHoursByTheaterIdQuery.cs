using Application.Common.CQRS.Query;
using Application.UseCases.Queries.WorkingHours.Dtos;

namespace Application.UseCases.Queries.WorkingHours.GetWorkingHoursByTheaterId;

public class GetWorkingHoursByTheaterIdQuery : IQuery<IReadOnlyList<GetWorkingHoursDto>>
{
    public int TheaterId { get; init; }
}
