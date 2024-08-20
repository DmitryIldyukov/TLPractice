using System.ComponentModel.DataAnnotations;
using Application.Common.CQRS.Command;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.UseCases.Commands.Theater.Update;

public class UpdateTheaterCommandHandler : ICommandHandler<UpdateTheaterCommand, Unit>
{
    private readonly ITheaterRepository _theaterRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateTheaterCommand> _validator;

    public UpdateTheaterCommandHandler( 
        ITheaterRepository theaterRepository, 
        IUnitOfWork unitOfWork,
        IValidator<UpdateTheaterCommand> validator )
    {
        _theaterRepository = theaterRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Unit> Handle( UpdateTheaterCommand command, CancellationToken cancellationToken )
    {
        var validationResult = await _validator.ValidateAsync( command, cancellationToken );
        if ( !validationResult.IsValid )
        {
            throw new FluentValidation.ValidationException( validationResult.Errors );
        }

        Domain.Entities.Theater theater = await _theaterRepository.GetById( command.TheaterId ) 
            ?? throw new NotFoundException( "Театр не найден." );

        theater.Name = command.Name;
        theater.Description = command.Description;
        theater.PhoneNumber = command.PhoneNumber;

        await _unitOfWork.SaveChangesAsync( cancellationToken );

        return Unit.Value;
    }
}
