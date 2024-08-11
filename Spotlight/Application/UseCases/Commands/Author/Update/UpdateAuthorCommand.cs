using Application.Common.CQRS.Command;
using MediatR;

namespace Application.UseCases.Commands.Author.Update;

public class UpdateAuthorCommand : ICommand<Unit>
{
    public int AuthorId { get; init; }
    public string Name { get; init; }
}
