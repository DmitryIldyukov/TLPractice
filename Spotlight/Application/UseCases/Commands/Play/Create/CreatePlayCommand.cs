using Application.Common.CQRS.Command;

namespace Application.UseCases.Commands.Play.Create;

public class CreatePlayCommand : ICommand<int>
{
    public string Name { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public decimal TicketPrice { get; init; }
    public string Description { get; init; }
    public int TheaterId { get; init; }
    public int CompositionId { get; init; }
}
