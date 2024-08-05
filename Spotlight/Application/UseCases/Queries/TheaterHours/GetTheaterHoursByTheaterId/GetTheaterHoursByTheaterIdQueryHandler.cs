using Application.Common.CQRS.Query;
using Application.Interfaces.Repositories;
using Application.UseCases.Queries.TheaterHours.Dtos;
using Domain.Exceptions;
using FluentValidation;

namespace Application.UseCases.Queries.TheaterHours.GetTheaterHoursByTheaterId;

public class GetTheaterHoursByTheaterIdQueryHandler : IQueryHandler<GetTheaterHoursByTheaterIdQuery, IReadOnlyList<GetTheaterHoursDto>>
{
    private readonly ITheaterHoursRepository _theaterHoursRepository;
    private readonly ITheaterRepository _theaterRepository;
    private readonly IValidator<GetTheaterHoursByTheaterIdQuery> _validator;

    public GetTheaterHoursByTheaterIdQueryHandler( 
        ITheaterHoursRepository theaterHoursRepository, 
        ITheaterRepository theaterRepository,
        IValidator<GetTheaterHoursByTheaterIdQuery> validator )
    {
        _theaterHoursRepository = theaterHoursRepository;
        _theaterRepository = theaterRepository;
        _validator = validator;
    }

    public async Task<IReadOnlyList<GetTheaterHoursDto>> Handle( GetTheaterHoursByTheaterIdQuery query, CancellationToken cancellationToken )
    {
        var validationResult = await _validator.ValidateAsync( query, cancellationToken );
        if ( !validationResult.IsValid )
        {
            throw new ValidationException( validationResult.Errors );
        }

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
