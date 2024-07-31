using Application.Common.CQRS.Query;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.UseCases.Queries.Theater.Dtos;

namespace Application.UseCases.Queries.Theater.GetById;

public class GetTheaterByIdQueryHandler : IQueryHandler<GetTheaterByIdQuery, GetTheaterDto>
{
    private readonly ITheaterRepository _theaterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetTheaterByIdQueryHandler( ITheaterRepository theaterRepository, IUnitOfWork unitOfWork )
    {
        _theaterRepository = theaterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<GetTheaterDto> Handle( GetTheaterByIdQuery query, CancellationToken cancellationToken )
    {
        Domain.Entities.Theater theater = await _theaterRepository.GetById( query.TheaterId ) 
            ?? throw new ArgumentException( "Театр не найден." );

        GetTheaterDto response = new()
        {
            TheaterId = theater.TheaterId,
            Name = theater.Name,
            Address = theater.Address,
            FirstOpeningDate = theater.FirstOpeningDate,
            Description = theater.Description,
            PhoneNumber = theater.PhoneNumber,
        };

        return response;
    }
}
