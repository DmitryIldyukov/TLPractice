using Application.Common.CQRS.Query;
using Application.UseCases.Queries.Theater.Dtos;

namespace Application.UseCases.Queries.Theater.GetById;

public class GetTheaterByIdQuery : IQuery<GetTheaterDto>
{
    public int TheaterId { get; init; }
}
