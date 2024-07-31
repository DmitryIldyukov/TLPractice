using Application.Common.CQRS.Query;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.UseCases.Queries.Author.Dtos;

namespace Application.UseCases.Queries.Author.GetById;

public class GetAuthorByIdQueryHandler : IQueryHandler<GetAuthorByIdQuery, GetAuthorQueryDto>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAuthorByIdQueryHandler( IAuthorRepository authorRepository, IUnitOfWork unitOfWork )
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<GetAuthorQueryDto> Handle( GetAuthorByIdQuery query, CancellationToken cancellationToken )
    {
        Domain.Entities.Author author = await _authorRepository.GetById( query.AuthorId )
            ?? throw new ArgumentException( "Автор не найден." );

        GetAuthorQueryDto response = new()
        {
            AuthorId = author.AuthorId,
            Name = author.Name,
            Birthday = author.Birthday,
        };

        return response;
    }
}
