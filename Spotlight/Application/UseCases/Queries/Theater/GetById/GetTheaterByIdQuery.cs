using Application.UseCases.Queries.Theater.Dtos;
using MediatR;

namespace Application.UseCases.Queries.Theater.GetById;

public class GetTheaterByIdQuery : IRequest<GetTheaterDto>
{
    public int TheaterId { get; init; }
}
