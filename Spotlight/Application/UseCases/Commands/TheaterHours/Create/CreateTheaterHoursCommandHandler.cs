using Application.Common.CQRS.Command;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Exceptions;

namespace Application.UseCases.Commands.TheaterHours.Create;

public class CreateTheaterHoursCommandHandler : ICommandHandler<CreateTheaterHoursCommand, int>
{
    private readonly ITheaterHoursRepository _theaterHoursRepository;
    private readonly ITheaterRepository _theaterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTheaterHoursCommandHandler(
        ITheaterHoursRepository theaterHoursRepository,
        ITheaterRepository theaterRepository,
        IUnitOfWork unitOfWork )
    {
        _theaterHoursRepository = theaterHoursRepository;
        _theaterRepository = theaterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle( CreateTheaterHoursCommand command, CancellationToken cancellationToken )
    {
        if ( command.OpeningTime >= command.ClosingTime )
        {
            throw new ArgumentException( "Дата открытия должна быть раньше даты закрытия." );
        }

        if ( await _theaterRepository.GetById( command.TheaterId ) is null )
        {
            throw new NotFoundException( "Театр не найден." );
        }

        if ( await _theaterHoursRepository.GetOnDayOfWeek( command.TheaterId, command.DayOfWeek ) is not null )
        {
            throw new ArgumentException( "У театра на этот день недели уже настроено расписание." );
        }

        Domain.Entities.TheaterHours theaterHours = new( command.DayOfWeek, command.OpeningTime, command.ClosingTime, command.TheaterId );

        await _theaterHoursRepository.Create( theaterHours );

        await _unitOfWork.SaveChangesAsync();

        return theaterHours.TheaterHoursId;
    }
}
