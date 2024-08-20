using Application.Common.CQRS.Query;
using Application.UseCases.Queries.Author.Dtos;

namespace Application.UseCases.Queries.Author.GetAll;

public class GetAllAuthorQuery : IQuery<IReadOnlyList<GetAuthorQueryDto>>
{ }
