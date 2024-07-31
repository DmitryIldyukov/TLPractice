using Application.Common.CQRS.Command;
using Application.Interfaces;
using Application.Interfaces.Repositories;

namespace Application.UseCases.Commands.Author.Create;

public class CreateAuthorCommandHandler : ICommandHandler<CreateAuthorCommand, int>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAuthorCommandHandler( IAuthorRepository authorRepository, IUnitOfWork unitOfWork )
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle( CreateAuthorCommand command, CancellationToken cancellationToken )
    {
        if ( string.IsNullOrEmpty( command.Name ) )
        {
            throw new ArgumentException( "Имя автора не может быть пустым." );
        }

        int age = DateTime.Now.Year - command.Birthday.Year;

        if ( age < 5 )
        {
            throw new ArgumentException( "Минимальный возраст автора 5 лет." );
        }
        Domain.Entities.Author author = new Domain.Entities.Author( command.Name, command.Birthday );

        await _authorRepository.Create( author );

        await _unitOfWork.SaveChangesAsync( cancellationToken );

        return author.AuthorId;
    }
}
