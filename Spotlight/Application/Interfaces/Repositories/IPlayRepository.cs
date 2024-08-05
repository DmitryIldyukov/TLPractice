using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IPlayRepository
{
    Task<IEnumerable<Play>> GetAllTheaterPlays( int theaterId );
    Task<Play> GetById( int id );
    Task Create( Play play );
    Task Delete( int id );
    Task<IEnumerable<Play>> GetByDateFilter( DateTime startDate, DateTime endDate );
}
