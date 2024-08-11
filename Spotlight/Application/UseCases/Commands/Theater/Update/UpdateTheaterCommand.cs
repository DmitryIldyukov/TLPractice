using Application.Common.CQRS.Command;
using MediatR;

namespace Application.UseCases.Commands.Theater.Update;

public class UpdateTheaterCommand : ICommand<Unit>
{
    public int TheaterId { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public string PhoneNumber { get; init; }
}
