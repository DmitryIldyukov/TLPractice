using MediatR;

namespace Application.UseCases.Commands.Author.Delete;

public class DeleteAuthorCommand : IRequest
{
    public int AuthorId { get; init; }
}
