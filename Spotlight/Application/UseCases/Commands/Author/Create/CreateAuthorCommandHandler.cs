using Application.Common.CQRS.Command;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using FluentValidation;

namespace Application.UseCases.Commands.Author.Create;

public class CreateAuthorCommandHandler : ICommandHandler<CreateAuthorCommand, int>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateAuthorCommand> _validator;

    public CreateAuthorCommandHandler( IAuthorRepository authorRepository, IUnitOfWork unitOfWork, IValidator<CreateAuthorCommand> validator )
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<int> Handle( CreateAuthorCommand command, CancellationToken cancellationToken )
    {
        var validationResult = await _validator.ValidateAsync( command, cancellationToken );
        if ( !validationResult.IsValid )
        {
            throw new ValidationException( validationResult.Errors );
        }

        Domain.Entities.Author author = new Domain.Entities.Author( command.Name, command.Birthday );

        await _authorRepository.Create( author );

        await _unitOfWork.SaveChangesAsync( cancellationToken );

        return author.AuthorId;
    }
}
