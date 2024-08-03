using Application.Common.CQRS.Query;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.UseCases.Queries.TheaterHours.Dtos;
using Domain.Exceptions;

namespace Application.UseCases.Queries.TheaterHours.GetTheaterHoursOnDayOfWeek;

public class GetTheaterHoursOnDayOfWeekQueryHandler : IQueryHandler<GetTheaterHoursOnDayOfWeekQuery, GetTheaterHoursDto>
{
    private readonly ITheaterHoursRepository _theaterHoursRepository;
    private readonly ITheaterRepository _theaterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetTheaterHoursOnDayOfWeekQueryHandler( ITheaterHoursRepository theaterHoursRepository, ITheaterRepository theaterRepository, IUnitOfWork unitOfWork )
    {
        _theaterHoursRepository = theaterHoursRepository;
        _theaterRepository = theaterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<GetTheaterHoursDto> Handle( GetTheaterHoursOnDayOfWeekQuery query, CancellationToken cancellationToken )
    {
        if ( await _theaterRepository.GetById( query.TheaterId ) is null )
        {
            throw new NotFoundException( "Театр не найден." );
        }

        Domain.Entities.TheaterHours theaterHours = await _theaterHoursRepository.GetOnDayOfWeek( query.TheaterId, query.DayOfWeek )
            ?? throw new NotFoundException( "Часы работы не найдены." );

        GetTheaterHoursDto response = new()
        {
            TheaterHoursId = theaterHours.TheaterHoursId,
            TheaterId = theaterHours.TheaterId,
            DayOfWeek = theaterHours.DayOfWeek,
            OpeningTime = theaterHours.OpeningTime,
            ClosingTime = theaterHours.ClosingTime,
        };

        return response;
    }
}
