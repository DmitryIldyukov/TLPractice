using Application.Common.CQRS.Query;
using Application.Interfaces.Repositories;
using Application.UseCases.Queries.TheaterHours.Dtos;
using Domain.Exceptions;

namespace Application.UseCases.Queries.TheaterHours.GetTheaterHoursByTheaterId;

public class GetTheaterHoursByTheaterIdQueryHandler : IQueryHandler<GetTheaterHoursByTheaterIdQuery, IReadOnlyList<GetTheaterHoursDto>>
{
    private readonly ITheaterHoursRepository _theaterHoursRepository;
    private readonly ITheaterRepository _theaterRepository;

    public GetTheaterHoursByTheaterIdQueryHandler( ITheaterHoursRepository theaterHoursRepository, ITheaterRepository theaterRepository )
    {
        _theaterHoursRepository = theaterHoursRepository;
        _theaterRepository = theaterRepository;
    }

    public async Task<IReadOnlyList<GetTheaterHoursDto>> Handle( GetTheaterHoursByTheaterIdQuery query, CancellationToken cancellationToken )
    {
        if ( _theaterRepository.GetById( query.TheaterId ) is null )
        {
            throw new NotFoundException( "Театр не найден." );
        }

        IEnumerable<Domain.Entities.TheaterHours> theaterHours = await _theaterHoursRepository.GetTheaterHours( query.TheaterId );

        IReadOnlyList<GetTheaterHoursDto> response = theaterHours.Select( wh => new GetTheaterHoursDto()
        {
            TheaterHoursId = wh.TheaterHoursId,
            TheaterId = wh.TheaterId,
            DayOfWeek = wh.DayOfWeek,
            OpeningTime = wh.OpeningTime,
            ClosingTime = wh.ClosingTime
        } ).ToList();

        return response;
    }
}
