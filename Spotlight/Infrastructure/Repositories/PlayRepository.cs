using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PlayRepository : IPlayRepository
{
    private readonly SpotlightDbContext _context;

    public PlayRepository( SpotlightDbContext context )
    {
        _context = context;
    }

    public async Task Create( Play play )
    {
        await _context.Plays.AddAsync( play );
        await _context.SaveChangesAsync();
    }

    public async Task Delete( int id )
    {
        Play play = await GetById( id );
        if ( play is not null )
        {
            _context.Plays.Remove( play );
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Play>> GetAllTheaterPlays( int theaterId )
    {
        return await _context.Plays
            .Include( p => p.Theater )
            .Include( p => p.Composition )
            .Where( p => p.TheaterId == theaterId )
            .ToListAsync();
    }

    public async Task<IEnumerable<Play>> GetByDateFilter( DateTime startDate, DateTime endDate )
    {
        return await _context.Plays
            .Include( p => p.Theater )
            .Include( p => p.Composition )
            .Where( p => p.StartDate >= startDate && p.EndDate <= endDate )
            .ToListAsync();
    }

    public async Task<Play> GetById( int id )
    {
        return await _context.Plays
            .Include( p => p.Theater )
            .Include( p => p.Composition )
            .FirstOrDefaultAsync( p => p.PlayId == id );
    }
}
