using Application.Interfaces.Repositories;
using Application.UseCases.Queries.Play.Dtos;
using MediatR;

namespace Application.UseCases.Queries.Play.GetByFilter;

public class GetPlaysForPeriodDatesQueryHandler : IRequestHandler<GetPlaysForPeriodDatesQuery, IReadOnlyList<GetPlayDto>>
{
    private readonly IPlayRepository _playRepository;

    public GetPlaysForPeriodDatesQueryHandler( IPlayRepository playRepository )
    {
        _playRepository = playRepository;
    }

    public async Task<IReadOnlyList<GetPlayDto>> Handle( GetPlaysForPeriodDatesQuery query, CancellationToken cancellationToken )
    {
        if ( query.StartDate >= query.EndDate )
        {
            throw new ArgumentException( "Неправильно указан период дат: дата начала не может быть позже даты окончания." );
        }

        IEnumerable<Domain.Entities.Play> plays = await _playRepository.GetByDateFilter( query.StartDate, query.EndDate );

        IReadOnlyList<GetPlayDto> response = plays.Select( p => new GetPlayDto()
        {
            PlayId = p.PlayId,
            StartDate = p.StartDate,
            EndDate = p.EndDate,
            TicketPrice = p.TicketPrice,
            Description = p.Description,
            TheaterName = p.Theater.Name,
            CompositionName = p.Composition.Name,
            CompositionDescription = p.Composition.ShortDescription,
            HeroesInformation = p.Composition.HeroesInformation,
        } ).ToList();

        return response;
    }
}
