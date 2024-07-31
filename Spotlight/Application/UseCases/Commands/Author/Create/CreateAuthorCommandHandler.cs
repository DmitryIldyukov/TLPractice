using Application.Interfaces;
using Application.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Commands.Author.Create;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAuthorCommandHandler( IAuthorRepository authorRepository, IUnitOfWork unitOfWork )
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle( CreateAuthorCommand command, CancellationToken cancellationToken )
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

        return Unit.Value;
    }
}
