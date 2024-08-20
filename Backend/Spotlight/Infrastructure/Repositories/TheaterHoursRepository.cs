using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TheaterHoursRepository : ITheaterHoursRepository
{
    private readonly SpotlightDbContext _context;

    public TheaterHoursRepository( SpotlightDbContext context )
    {
        _context = context;
    }

    public async Task Create( TheaterHours theaterHours )
    {
        await _context.TheaterHours.AddAsync( theaterHours );
    }

    public async Task<IEnumerable<TheaterHours>> GetTheaterHours( int theaterId )
    {
        return await _context.TheaterHours
            .Where( wh => wh.TheaterId == theaterId )
            .OrderBy( wh => wh.DayOfWeek )
            .ToListAsync();
    }

    public async Task Delete( int theaterHoursId )
    {
        TheaterHours theaterHours = await GetById( theaterHoursId );
        if ( theaterHours is not null )
        {
            _context.TheaterHours.Remove( theaterHours );
        }
    }

    public async Task<TheaterHours> GetById( int id )
    {
        return await _context.TheaterHours
            .Include( t => t.Theater )
            .FirstOrDefaultAsync( wh => wh.TheaterHoursId == id );
    }

    public async Task<TheaterHours> GetOnDayOfWeek( int theaterId, DayOfWeek dayOfWeek )
    {
        return await _context.TheaterHours
            .Include( t => t.Theater )
            .FirstOrDefaultAsync( wh => wh.TheaterId == theaterId && wh.DayOfWeek == dayOfWeek );
    }
}
