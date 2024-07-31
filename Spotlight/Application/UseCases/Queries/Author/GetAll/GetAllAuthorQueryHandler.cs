using Application.Common.CQRS.Query;
using Application.Interfaces.Repositories;
using Application.UseCases.Queries.Author.Dtos;

namespace Application.UseCases.Queries.Author.GetAll;

public class GetAllAuthorQueryHandler : IQueryHandler<GetAllAuthorQuery, IReadOnlyList<GetAuthorQueryDto>>
{
    private readonly IAuthorRepository _authorRepository;

    public GetAllAuthorQueryHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<IReadOnlyList<GetAuthorQueryDto>> Handle( GetAllAuthorQuery request, CancellationToken cancellationToken )
    {
        IEnumerable<Domain.Entities.Author> authors = await _authorRepository.GetAll();

        IReadOnlyList<GetAuthorQueryDto> response = authors.Select( author => new GetAuthorQueryDto()
        {
            Id = author.AuthorId,
            Name = author.Name,
            Birthday = author.Birthday,
        } ).ToList();

        return response;
    }
}
