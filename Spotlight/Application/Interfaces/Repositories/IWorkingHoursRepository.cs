using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IWorkingHoursRepository
{
    Task CreateWorkingHours( WorkingHours workingHours );
    Task<IEnumerable<WorkingHours>> GetTheaterWorkingHours( int theaterId );
    Task DeleteWorkingHours( int workingHoursId );
    Task<WorkingHours> GetById( int id );
    Task<WorkingHours> GetOnDayOfWeek( int theaterId, DayOfWeek dayOfWeek );
}