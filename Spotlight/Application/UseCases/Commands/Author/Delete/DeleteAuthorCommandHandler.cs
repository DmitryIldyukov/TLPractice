using Application.Interfaces;
using Application.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Commands.Author.Delete;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAuthorCommandHandler( IAuthorRepository authorRepository, IUnitOfWork unitOfWork )
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle( DeleteAuthorCommand command, CancellationToken cancellationToken )
    {
        await _authorRepository.Delete( command.AuthorId );

        await _unitOfWork.SaveChangesAsync( cancellationToken );

        return Unit.Value;
    }
}
