using Application.Common.CQRS.Query;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.UseCases.Queries.WorkingHours.Dtos;
using Domain.Entities;

namespace Application.UseCases.Queries.WorkingHours.GetWorkingHoursOnDayOfWeek;

public class GetWorkingHoursOnDayOfWeekQueryHandler : IQueryHandler<GetWorkingHoursOnDayOfWeekQuery, GetWorkingHoursDto>
{
    private readonly IWorkingHoursRepository _workingHoursRepository;
    private readonly ITheaterRepository _theaterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetWorkingHoursOnDayOfWeekQueryHandler( IWorkingHoursRepository workingHoursRepository, ITheaterRepository theaterRepository, IUnitOfWork unitOfWork )
    {
        _workingHoursRepository = workingHoursRepository;
        _theaterRepository = theaterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<GetWorkingHoursDto> Handle( GetWorkingHoursOnDayOfWeekQuery query, CancellationToken cancellationToken )
    {
        if ( await _theaterRepository.GetById( query.TheaterId ) is null )
            throw new ArgumentException( "Театр не найден." );

        Domain.Entities.WorkingHours workingHours = await _workingHoursRepository.GetOnDayOfWeek( query.TheaterId, query.DayOfWeek )
            ?? throw new ArgumentException( "Часы работы не найдены." );

        GetWorkingHoursDto response = new()
        {
            WorkingHoursId = workingHours.WorkingHoursId,
            TheaterId = workingHours.TheaterId,
            DayOfWeek = workingHours.DayOfWeek,
            OpeningTime = workingHours.OpeningTime,
            ClosingTime = workingHours.ClosingTime,
        };

        return response;
    }
}
