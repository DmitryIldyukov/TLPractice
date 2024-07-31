using Application.Common.CQRS.Command;

namespace Application.UseCases.Commands.Author.Create;

public class CreateAuthorCommand : ICommand<int>
{
    public string Name { get; init; }
    public DateTime Birthday { get; init; }
}
