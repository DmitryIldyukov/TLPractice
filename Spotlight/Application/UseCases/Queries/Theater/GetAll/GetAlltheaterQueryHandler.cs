using Application.Common.CQRS.Query;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.UseCases.Queries.Theater.Dtos;

namespace Application.UseCases.Queries.Theater.GetAll;

public class GetAllTheaterQueryHandler : IQueryHandler<GetAllTheaterQuery, IReadOnlyList<GetTheaterDto>>
{
    private readonly ITheaterRepository _theaterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTheaterQueryHandler( ITheaterRepository theaterRepository, IUnitOfWork unitOfWork )
    {
        _theaterRepository = theaterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<GetTheaterDto>> Handle( GetAllTheaterQuery request, CancellationToken cancellationToken )
    {
        IEnumerable<Domain.Entities.Theater> theaters = await _theaterRepository.GetAll();

        IReadOnlyList<GetTheaterDto> response = theaters.Select( t => new GetTheaterDto()
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