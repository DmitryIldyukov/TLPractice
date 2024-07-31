using MediatR;

namespace Application.UseCases.Commands.Author.Update;

public class UpdateAuthorCommand : IRequest
{
    public int AuthorId { get; init; }
    public string Name { get; init; }
}
