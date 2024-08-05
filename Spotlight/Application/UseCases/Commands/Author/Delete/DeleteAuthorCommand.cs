using Application.Common.CQRS.Command;
using MediatR;

namespace Application.UseCases.Commands.Author.Delete;

public class DeleteAuthorCommand : ICommand<Unit>
{
    public int AuthorId { get; init; }
}
