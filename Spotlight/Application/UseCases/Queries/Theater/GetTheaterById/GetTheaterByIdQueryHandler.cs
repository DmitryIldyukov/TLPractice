using Application.Common.CQRS.Query;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.UseCases.Queries.Theater.Dtos;
using Domain.Exceptions;
using FluentValidation;

namespace Application.UseCases.Queries.Theater.GetById;

public class GetTheaterByIdQueryHandler : IQueryHandler<GetTheaterByIdQuery, GetTheaterDto>
{
    private readonly ITheaterRepository _theaterRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<GetTheaterByIdQuery> _validator;

    public GetTheaterByIdQueryHandler( 
        ITheaterRepository theaterRepository, 
        IUnitOfWork unitOfWork,
        IValidator<GetTheaterByIdQuery> validator )
    {
        _theaterRepository = theaterRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<GetTheaterDto> Handle( GetTheaterByIdQuery query, CancellationToken cancellationToken )
    {
        var validationResult = await _validator.ValidateAsync( query, cancellationToken );
        if ( !validationResult.IsValid )
        {
            throw new FluentValidation.ValidationException( validationResult.Errors );
        }

        Domain.Entities.Theater theater = await _theaterRepository.GetById( query.TheaterId ) 
            ?? throw new NotFoundException( "Театр не найден." );

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
