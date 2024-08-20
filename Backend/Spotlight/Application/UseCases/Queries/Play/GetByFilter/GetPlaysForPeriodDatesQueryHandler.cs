using Application.Common.CQRS.Query;
using Application.Interfaces.Repositories;
using Application.UseCases.Queries.Play.Dtos;
using FluentValidation;

namespace Application.UseCases.Queries.Play.GetByFilter;

public class GetPlaysForPeriodDatesQueryHandler : IQueryHandler<GetPlaysForPeriodDatesQuery, IReadOnlyList<GetPlayDto>>
{
    private readonly IPlayRepository _playRepository;
    private readonly IValidator<GetPlaysForPeriodDatesQuery> _validator;

    public GetPlaysForPeriodDatesQueryHandler( IPlayRepository playRepository, IValidator<GetPlaysForPeriodDatesQuery> validator )
    {
        _playRepository = playRepository;
        _validator = validator;
    }

    public async Task<IReadOnlyList<GetPlayDto>> Handle( GetPlaysForPeriodDatesQuery query, CancellationToken cancellationToken )
    {
        var validationResult = await _validator.ValidateAsync( query, cancellationToken );
        if ( !validationResult.IsValid )
        {
            throw new ValidationException( validationResult.Errors );
        }

        IEnumerable<Domain.Entities.Play> plays = await _playRepository.GetByDateFilter( query.StartDate, query.EndDate );

        IReadOnlyList<GetPlayDto> response = plays.Select( p => new GetPlayDto()
        {
            PlayId = p.PlayId,
            Name = p.Name,
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
