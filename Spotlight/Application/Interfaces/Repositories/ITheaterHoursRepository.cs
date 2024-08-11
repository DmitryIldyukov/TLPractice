using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface ITheaterHoursRepository
{
    Task Create( TheaterHours theaterHours );
    Task Delete( int theaterHoursId );
    Task<TheaterHours> GetById( int id );
    Task<IEnumerable<TheaterHours>> GetTheaterHours( int theaterId );
    Task<TheaterHours> GetOnDayOfWeek( int theaterId, DayOfWeek dayOfWeek );
}