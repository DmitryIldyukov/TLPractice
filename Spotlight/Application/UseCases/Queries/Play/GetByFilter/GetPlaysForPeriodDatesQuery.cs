using Application.UseCases.Queries.Play.Dtos;
using MediatR;

namespace Application.UseCases.Queries.Play.GetByFilter;

public class GetPlaysForPeriodDatesQuery : IRequest<IReadOnlyList<GetPlayDto>>
{
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
}
