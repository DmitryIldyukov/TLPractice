using MediatR;

namespace Application.UseCases.Commands.Theater.Delete;

public class DeleteTheaterCommand : IRequest
{
    public int TheaterId { get; init; }
}
