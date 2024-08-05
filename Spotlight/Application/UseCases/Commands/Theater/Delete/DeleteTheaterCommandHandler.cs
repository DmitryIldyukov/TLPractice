using Application.Common.CQRS.Command;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using FluentValidation;
using MediatR;

namespace Application.UseCases.Commands.Theater.Delete;

public class DeleteTheaterCommandHandler : ICommandHandler<DeleteTheaterCommand, Unit>
{
    private readonly ITheaterRepository _theaterRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<DeleteTheaterCommand> _validator;

    public DeleteTheaterCommandHandler(
        ITheaterRepository theaterRepository,
        IUnitOfWork unitOfWork,
        IValidator<DeleteTheaterCommand> validator )
    {
        _theaterRepository = theaterRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Unit> Handle( DeleteTheaterCommand command, CancellationToken cancellationToken )
    {
        var validationResult = await _validator.ValidateAsync( command, cancellationToken );
        if ( !validationResult.IsValid )
        {
            throw new ValidationException( validationResult.Errors );
        }

        await _theaterRepository.Delete( command.TheaterId );

        await _unitOfWork.SaveChangesAsync( cancellationToken );

        return Unit.Value;
    }
}
