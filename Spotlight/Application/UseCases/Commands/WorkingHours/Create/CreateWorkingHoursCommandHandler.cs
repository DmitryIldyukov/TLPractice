using Application.Interfaces;
using Application.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Commands.WorkingHours.Create;

public class CreateWorkingHoursCommandHandler : IRequestHandler<CreateWorkingHoursCommand>
{
    private readonly IWorkingHoursRepository _workingHoursRepository;
    private readonly ITheaterRepository _theaterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateWorkingHoursCommandHandler( IWorkingHoursRepository workingHoursRepository, ITheaterRepository theaterRepository, IUnitOfWork unitOfWork )
    {
        _workingHoursRepository = workingHoursRepository;
        _theaterRepository = theaterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle( CreateWorkingHoursCommand command, CancellationToken cancellationToken )
    {
        if ( command.OpeningTime >= command.ClosingTime )
        {
            throw new ArgumentException( "Дата открытия должна быть раньше даты закрытия." );
        }

        if ( await _theaterRepository.GetById( command.TheaterId ) is null )
        {
            throw new ArgumentException( "Театр не найден." );
        }

        if ( await _workingHoursRepository.GetOnDayOfWeek(command.TheaterId, command.DayOfWeek) is not null)
        {
            throw new ArgumentException( "У театра на этот день недели уже настроено расписание." );
        }

        Domain.Entities.WorkingHours workingHours = new( command.DayOfWeek, command.OpeningTime, command.ClosingTime, command.TheaterId );

        await _workingHoursRepository.CreateWorkingHours(workingHours);

        await _unitOfWork.SaveChangesAsync( cancellationToken );

        return Unit.Value;
    }
}
