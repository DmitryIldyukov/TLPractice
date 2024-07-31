using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface ITheaterRepository
{
    Task<IEnumerable<Theater>> GetAll();
    Task<Theater> GetById(int id);
    Task Create(Theater theater);
    Task Delete(int id);
}
