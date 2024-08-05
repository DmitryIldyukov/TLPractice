using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface ICompositionRepository
{
    Task<IEnumerable<Composition>> GetAllAuthorCompositions( int authorId );
    Task<Composition> GetById( int id );
    Task Create( Composition composition );
    Task Delete( int id );
}
