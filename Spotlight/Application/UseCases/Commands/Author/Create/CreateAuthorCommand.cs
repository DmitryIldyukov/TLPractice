using MediatR;

namespace Application.UseCases.Commands.Author.Create;

public class CreateAuthorCommand : IRequest
{
    public string Name { get; init; }
    public DateTime Birthday { get; init; }
}
