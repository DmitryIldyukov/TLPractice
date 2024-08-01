using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TheaterRepository : ITheaterRepository
{
    public readonly SpotlightDbContext _context;

    public TheaterRepository( SpotlightDbContext context )
    {
        _context = context;
    }

    public async Task Create( Theater theater )
    {
        await _context.Theaters.AddAsync( theater );
    }

    public async Task Delete( int id )
    {
        Theater theater = await GetById( id );
        if ( theater is not null )
        {
            _context.Theaters.Remove( theater );
        }
    }

    public async Task<IEnumerable<Theater>> GetAll()
    {
        return await _context.Theaters
            .Include( t => t.Plays )
            .Include( t => t.WorkingHours )
            .ToListAsync();
    }

    public async Task<Theater> GetById( int id )
    {
        return await _context.Theaters
            .Include( t => t.Plays )
            .Include( t => t.WorkingHours )
            .FirstOrDefaultAsync( t => t.TheaterId == id );
    }
}
