using Application.Common.CQRS.Query;
using Application.UseCases.Queries.Play.Dtos;

namespace Application.UseCases.Queries.Play.GetByFilter;

public class GetPlaysForPeriodDatesQuery : IQuery<IReadOnlyList<GetPlayDto>>
{
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
}
