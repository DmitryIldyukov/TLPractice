using Application.Common.CQRS.Command;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Exceptions;
using FluentValidation;

namespace Application.UseCases.Commands.Composition.Create;

public class CreateCompositionCommandHandler : ICommandHandler<CreateCompositionCommand, int>
{
    private readonly ICompositionRepository _compositionRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateCompositionCommand> _validator;

    public CreateCompositionCommandHandler(
        ICompositionRepository compositionRepository,
        IAuthorRepository authorRepository,
        IUnitOfWork unitOfWork,
        IValidator<CreateCompositionCommand> validator )
    {
        _compositionRepository = compositionRepository;
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<int> Handle( CreateCompositionCommand request, CancellationToken cancellationToken )
    {
        var validationResult = await _validator.ValidateAsync( request, cancellationToken );
        if ( !validationResult.IsValid )
        {
            throw new ValidationException( validationResult.Errors );
        }

        if ( await _authorRepository.GetById( request.AuthorId ) is null )
        {
            throw new NotFoundException( "Автор не найден." );
        }

        Domain.Entities.Composition composition = new Domain.Entities.Composition(
            request.Name,
            request.ShortDescription,
            request.HeroesInformation,
            request.AuthorId );

        await _compositionRepository.Create( composition );

        await _unitOfWork.SaveChangesAsync( cancellationToken );

        return composition.CompositionId;
    }
}
