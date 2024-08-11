using Application.Common.CQRS.Query;
using Application.UseCases.Queries.Theater.Dtos;

namespace Application.UseCases.Queries.Theater.GetAll;

public class GetAllTheaterQuery : IQuery<IReadOnlyList<GetTheaterDto>> { }
