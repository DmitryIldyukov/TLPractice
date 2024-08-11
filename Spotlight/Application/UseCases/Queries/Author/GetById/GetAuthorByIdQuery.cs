using Application.Common.CQRS.Query;
using Application.UseCases.Queries.Author.Dtos;

namespace Application.UseCases.Queries.Author.GetById;

public class GetAuthorByIdQuery : IQuery<GetAuthorQueryDto>
{
    public int AuthorId { get; init; }
}
