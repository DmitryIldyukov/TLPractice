using MediatR;

namespace Application.UseCases.Commands.Theater.Create;

public class CreateTheaterCommand : IRequest
{
    public string Name { get; init; }
    public string Address { get; init; }
    public DateTime FirstOpeningDate { get; init; }
    public string Description { get; init; }
    public string PhoneNumber { get; init; }
}
