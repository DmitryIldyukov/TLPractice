using Application.Common.CQRS.Command;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Commands.Theater.Delete;

public class DeleteTheaterCommandHandler : ICommandHandler<DeleteTheaterCommand, Unit>
{
    private readonly ITheaterRepository _theaterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTheaterCommandHandler( ITheaterRepository theaterRepository, IUnitOfWork unitOfWork )
    {
        _theaterRepository = theaterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle( DeleteTheaterCommand command, CancellationToken cancellationToken )
    {
        await _theaterRepository.Delete( command.TheaterId );

        await _unitOfWork.SaveChangesAsync( cancellationToken );

        return Unit.Value;
    }
}
