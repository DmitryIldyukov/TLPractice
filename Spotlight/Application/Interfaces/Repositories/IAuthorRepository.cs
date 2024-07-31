using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAll();
    Task<Author> GetById(int id);
    Task Create(Author author);
    Task Delete(int id);
}
