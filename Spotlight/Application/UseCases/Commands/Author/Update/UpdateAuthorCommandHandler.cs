using Application.Interfaces;
using Application.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Commands.Author.Update;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAuthorCommandHandler( IAuthorRepository authorRepository, IUnitOfWork unitOfWork )
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle( UpdateAuthorCommand command, CancellationToken cancellationToken )
    {
        if ( string.IsNullOrEmpty( command.Name ) )
        {
            throw new ArgumentException( "Имя автора не может быть пустым." );
        }

        Domain.Entities.Author author = await _authorRepository.GetById( command.AuthorId )
            ?? throw new ArgumentException( "Автор не найден." );

        author.Name = command.Name;

        await _unitOfWork.SaveChangesAsync( cancellationToken );

        return Unit.Value;
    }
}
