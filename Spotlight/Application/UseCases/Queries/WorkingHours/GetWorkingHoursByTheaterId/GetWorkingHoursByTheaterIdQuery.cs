using Application.UseCases.Queries.WorkingHours.Dtos;
using MediatR;

namespace Application.UseCases.Queries.WorkingHours.GetWorkingHoursByTheaterId;

public class GetWorkingHoursByTheaterIdQuery : IRequest<IReadOnlyList<GetWorkingHoursDto>>
{
    public int TheaterId { get; init; }
}
