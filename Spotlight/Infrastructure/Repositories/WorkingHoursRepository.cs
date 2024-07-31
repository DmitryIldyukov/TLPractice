using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class WorkingHoursRepository : IWorkingHoursRepository
{
    private readonly SpotlightDbContext _context;

    public WorkingHoursRepository( SpotlightDbContext context )
    {
        _context = context;
    }

    public async Task CreateWorkingHours( WorkingHours workingHours )
    {
        await _context.WorkingHours.AddAsync( workingHours );
    }

    public async Task<IEnumerable<WorkingHours>> GetTheaterWorkingHours( int theaterId )
    {
        return await _context.WorkingHours
            .Where( wh => wh.TheaterId == theaterId )
            .OrderBy( wh => wh.DayOfWeek )
            .ToListAsync();
    }

    public async Task DeleteWorkingHours( int workingHoursId )
    {
        WorkingHours workingHours = await GetById( workingHoursId );
        if ( workingHours is not null )
        {
            _context.WorkingHours.Remove( workingHours );
        }
    }

    public async Task<WorkingHours> GetById( int id )
    {
        return await _context.WorkingHours
            .Include( t => t.Theater )
            .FirstOrDefaultAsync( wh => wh.WorkingHoursId == id );
    }

    public async Task<WorkingHours> GetOnDayOfWeek( int theaterId, DayOfWeek dayOfWeek )
    {
        return await _context.WorkingHours
            .Include( t => t.Theater )
            .FirstOrDefaultAsync( wh => wh.TheaterId == theaterId && wh.DayOfWeek == dayOfWeek );
    }
}
