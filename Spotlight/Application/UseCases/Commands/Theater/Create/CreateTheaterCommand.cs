using Application.Common.CQRS.Command;

namespace Application.UseCases.Commands.Theater.Create;

public class CreateTheaterCommand : ICommand<int>
{
    public string Name { get; init; }
    public string Address { get; init; }
    public DateTime FirstOpeningDate { get; init; }
    public string Description { get; init; }
    public string PhoneNumber { get; init; }
}
