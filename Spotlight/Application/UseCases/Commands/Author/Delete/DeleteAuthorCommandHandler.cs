using Application.Common.CQRS.Command;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using FluentValidation;
using MediatR;

namespace Application.UseCases.Commands.Author.Delete;

public class DeleteAuthorCommandHandler : ICommandHandler<DeleteAuthorCommand, Unit>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<DeleteAuthorCommand> _validator;

    public DeleteAuthorCommandHandler( 
        IAuthorRepository authorRepository, 
        IUnitOfWork unitOfWork, 
        IValidator<DeleteAuthorCommand> validator )
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Unit> Handle( DeleteAuthorCommand command, CancellationToken cancellationToken )
    {
        var validationResult = await _validator.ValidateAsync( command, cancellationToken );
        if ( !validationResult.IsValid )
        {
            throw new FluentValidation.ValidationException( validationResult.Errors );
        }

        await _authorRepository.Delete( command.AuthorId );

        await _unitOfWork.SaveChangesAsync( cancellationToken );

        return Unit.Value;
    }
}
