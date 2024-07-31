using Application.Common.CQRS.Query;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.UseCases.Queries.Theater.Dtos;
using Application.UseCases.Queries.WorkingHours.Dtos;
using Domain.Entities;

namespace Application.UseCases.Queries.WorkingHours.GetWorkingHoursOnDayOfWeek;

public class GetWorkingHoursOnDayOfWeekQueryHandler : IQueryHandler<GetWorkingHoursOnDayOfWeekQuery, GetWorkingHoursDto>
{
    private readonly IWorkingHoursRepository _workingHoursRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetWorkingHoursOnDayOfWeekQueryHandler( IWorkingHoursRepository workingHoursRepository, IUnitOfWork unitOfWork )
    {
        _workingHoursRepository = workingHoursRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<GetWorkingHoursDto> Handle( GetWorkingHoursOnDayOfWeekQuery query, CancellationToken cancellationToken )
    {
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
