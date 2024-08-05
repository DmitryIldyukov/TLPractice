using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly SpotlightDbContext _context;

    public AuthorRepository( SpotlightDbContext context )
    {
        _context = context;
    }

    public async Task Create( Author author )
    {
        await _context.Authors.AddAsync( author );
    }

    public async Task Delete( int id )
    {
        Author author = await GetById( id );
        if ( author is not null )
        {
            _context.Authors.Remove( author );
        }
    }

    public async Task<IEnumerable<Author>> GetAll()
    {
        return await _context.Authors
            .Include( a => a.Compositions )
            .ToListAsync();
    }

    public async Task<Author> GetById( int id )
    {
        return await _context.Authors
            .Include( a => a.Compositions )
            .FirstOrDefaultAsync( a => a.AuthorId == id );
    }
}
