using Application.Common.CQRS.Command;
using MediatR;

namespace Application.UseCases.Commands.Theater.Delete;

public class DeleteTheaterCommand : ICommand<Unit>
{
    public int TheaterId { get; init; }
}
