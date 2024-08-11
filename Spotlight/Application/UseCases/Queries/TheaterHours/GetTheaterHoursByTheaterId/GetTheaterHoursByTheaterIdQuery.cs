using Application.Common.CQRS.Query;
using Application.UseCases.Queries.TheaterHours.Dtos;

namespace Application.UseCases.Queries.TheaterHours.GetTheaterHoursByTheaterId;

public class GetTheaterHoursByTheaterIdQuery : IQuery<IReadOnlyList<GetTheaterHoursDto>>
{
    public int TheaterId { get; init; }
}
