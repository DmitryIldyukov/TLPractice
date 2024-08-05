using Application.Common.CQRS.Command;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using FluentValidation;

namespace Application.UseCases.Commands.Theater.Create;

public class CreateTheaterCommandHandler : ICommandHandler<CreateTheaterCommand, int>
{
    private readonly ITheaterRepository _theaterRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateTheaterCommand> _validator;

    public CreateTheaterCommandHandler(
        ITheaterRepository theaterRepository,
        IUnitOfWork unitOfWork,
        IValidator<CreateTheaterCommand> validator )
    {
        _theaterRepository = theaterRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<int> Handle( CreateTheaterCommand command, CancellationToken cancellationToken )
    {
        var validationResult = await _validator.ValidateAsync( command, cancellationToken );
        if ( !validationResult.IsValid )
        {
            throw new ValidationException( validationResult.Errors );
        }

        Domain.Entities.Theater theater = new Domain.Entities.Theater(
            command.Name,
            command.Address,
            command.FirstOpeningDate,
            command.Description,
            command.PhoneNumber
        );

        await _theaterRepository.Create( theater );

        await _unitOfWork.SaveChangesAsync( cancellationToken );

        return theater.TheaterId;
    }
}
