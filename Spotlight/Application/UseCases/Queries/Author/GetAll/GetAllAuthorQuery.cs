using Application.UseCases.Queries.Author.Dtos;
using MediatR;

namespace Application.UseCases.Queries.Author.GetAll;

public class GetAllAuthorQuery : IRequest<IReadOnlyList<GetAuthorQueryDto>>
{

}
