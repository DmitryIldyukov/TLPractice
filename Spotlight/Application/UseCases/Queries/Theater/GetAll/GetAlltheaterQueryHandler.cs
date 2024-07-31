using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.UseCases.Queries.Theater.Dtos;
using MediatR;

namespace Application.UseCases.Queries.Theater.GetAll;

public class GetAllTheaterQueryHandler : IRequestHandler<GetAllTheaterQuery, IReadOnlyList<GetAllTheaterDto>>
{
    private readonly ITheaterRepository _theaterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTheaterQueryHandler( ITheaterRepository theaterRepository, IUnitOfWork unitOfWork )
    {
        _theaterRepository = theaterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<GetAllTheaterDto>> Handle( GetAllTheaterQuery request, CancellationToken cancellationToken )
    {
        IEnumerable<Domain.Entities.Theater> theaters = await _theaterRepository.GetAll();

        IReadOnlyList<GetAllTheaterDto> response = theaters.Select( t => new GetAllTheaterDto()
        {
            TheaterId = t.TheaterId,
            Name = t.Name,
            Address = t.Address,
            FirstOpeningDate = t.FirstOpeningDate,
            Description = t.Description,
            PhoneNumber = t.PhoneNumber
        } ).ToList();

        return response;
    }
}