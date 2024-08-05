using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CompositionRepository : ICompositionRepository
{
    private readonly SpotlightDbContext _context;

    public CompositionRepository( SpotlightDbContext context )
    {
        _context = context;
    }

    public async Task Create( Composition composition )
    {
        await _context.Compositions.AddAsync( composition );
    }

    public async Task Delete( int id )
    {
        Composition composition = await GetById( id );
        if ( composition is not null )
        {
            _context.Compositions.Remove( composition );
        }
    }

    public async Task<IEnumerable<Composition>> GetAllAuthorCompositions( int authorId )
    {
        return await _context.Compositions
            .Include( c => c.Plays )
            .Include( c => c.Author )
            .Where( c => c.AuthorId == authorId )
            .ToListAsync();
    }

    public Task<Composition> GetById( int id )
    {
        return _context.Compositions
            .Include( c => c.Plays )
            .Include( c => c.Author )
            .FirstOrDefaultAsync( c => c.CompositionId == id );
    }
}
