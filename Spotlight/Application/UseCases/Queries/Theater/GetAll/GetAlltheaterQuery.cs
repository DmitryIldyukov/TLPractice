using Application.UseCases.Queries.Theater.Dtos;
using MediatR;

namespace Application.UseCases.Queries.Theater.GetAll;

public class GetAllTheaterQuery : IRequest<IReadOnlyList<GetAllTheaterDto>> { }
