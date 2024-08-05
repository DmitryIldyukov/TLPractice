using Application.Common.CQRS.Command;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.UseCases.Commands.Author.Update;

public class UpdateAuthorCommandHandler : ICommandHandler<UpdateAuthorCommand, Unit>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateAuthorCommand> _validator;

    public UpdateAuthorCommandHandler( IAuthorRepository authorRepository, IUnitOfWork unitOfWork, IValidator<UpdateAuthorCommand> validator )
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Unit> Handle( UpdateAuthorCommand command, CancellationToken cancellationToken )
    {
        if ( string.IsNullOrEmpty( command.Name ) )
        {
            throw new ArgumentException( "Имя автора не может быть пустым." );
        }

        Domain.Entities.Author author = await _authorRepository.GetById( command.AuthorId )
            ?? throw new NotFoundException( "Автор не найден." );

        author.Name = command.Name;

        await _unitOfWork.SaveChangesAsync( cancellationToken );

        return Unit.Value;
    }
}
