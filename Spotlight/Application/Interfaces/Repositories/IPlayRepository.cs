using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IPlayRepository
{
    Task<IEnumerable<Play>> GetAll();
    Task<Play> GetById( int id );
    Task Create( Play play );
    Task Delete( int id );
    Task<IEnumerable<Play>> GetByDateFilter( DateTime startDate, DateTime endDate );
}
