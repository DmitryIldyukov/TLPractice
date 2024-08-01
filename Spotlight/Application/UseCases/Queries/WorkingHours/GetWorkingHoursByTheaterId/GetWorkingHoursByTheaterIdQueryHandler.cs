using Application.Common.CQRS.Query;
using Application.Interfaces.Repositories;
using Application.UseCases.Queries.WorkingHours.Dtos;
using Domain.Exceptions;

namespace Application.UseCases.Queries.WorkingHours.GetWorkingHoursByTheaterId;

public class GetWorkingHoursByTheaterIdQueryHandler : IQueryHandler<GetWorkingHoursByTheaterIdQuery, IReadOnlyList<GetWorkingHoursDto>>
{
    private readonly IWorkingHoursRepository _workingHoursRepository;
    private readonly ITheaterRepository _theaterRepository;

    public GetWorkingHoursByTheaterIdQueryHandler( IWorkingHoursRepository workingHoursRepository, ITheaterRepository theaterRepository )
    {
        _workingHoursRepository = workingHoursRepository;
        _theaterRepository = theaterRepository;
    }

    public async Task<IReadOnlyList<GetWorkingHoursDto>> Handle( GetWorkingHoursByTheaterIdQuery query, CancellationToken cancellationToken )
    {
        if ( _theaterRepository.GetById( query.TheaterId ) is null )
        {
            throw new NotFoundException( "Театр не найден." );
        }

        IEnumerable<Domain.Entities.WorkingHours> workingHours = await _workingHoursRepository.GetTheaterWorkingHours( query.TheaterId );

        IReadOnlyList<GetWorkingHoursDto> response = workingHours.Select( wh => new GetWorkingHoursDto()
        {
            WorkingHoursId = wh.WorkingHoursId,
            TheaterId = wh.TheaterId,
            DayOfWeek = wh.DayOfWeek,
            OpeningTime = wh.OpeningTime,
            ClosingTime = wh.ClosingTime
        } ).ToList();

        return response;
    }
}
