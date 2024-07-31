using Application.Common.CQRS.Command;
using Application.Interfaces;
using Application.Interfaces.Repositories;

namespace Application.UseCases.Commands.Composition.Create;

public class CreateCompositionCommandHandler : ICommandHandler<CreateCompositionCommand, int>
{
    private readonly ICompositionRepository _compositionRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCompositionCommandHandler( ICompositionRepository compositionRepository, IAuthorRepository authorRepository, IUnitOfWork unitOfWork )
    {
        _compositionRepository = compositionRepository;
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle( CreateCompositionCommand request, CancellationToken cancellationToken )
    {
        if ( string.IsNullOrEmpty( request.Name ) )
        {
            throw new ArgumentException( "Название композиции не может быть пустым." );
        }

        if ( string.IsNullOrEmpty( request.ShortDescription ) )
        {
            throw new ArgumentException( "Краткое описание не может быть пустым." );
        }

        if ( string.IsNullOrEmpty( request.HeroesInformation ) )
        {
            throw new ArgumentException( "Информация о героях не может быть пустой." );
        }

        if ( await _authorRepository.GetById( request.AuthorId ) is null )
        {
            throw new ArgumentException( "Автор не найден." );
        }

        Domain.Entities.Composition composition = new Domain.Entities.Composition( request.Name, request.ShortDescription, request.HeroesInformation, request.AuthorId );

        await _compositionRepository.Create( composition );

        await _unitOfWork.SaveChangesAsync( cancellationToken );

        return composition.CompositionId;
    }
}
