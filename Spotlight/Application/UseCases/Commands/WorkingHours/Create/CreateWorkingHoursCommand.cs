using MediatR;

namespace Application.UseCases.Commands.WorkingHours.Create;

public class CreateWorkingHoursCommand : IRequest
{
    public int TheaterId { get; init; }
    public DayOfWeek DayOfWeek { get; init; }
    public TimeSpan OpeningTime { get; init; }
    public TimeSpan ClosingTime { get; init; }
}
