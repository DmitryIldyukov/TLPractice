using Application.Common.CQRS.Command;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Exceptions;
using FluentValidation;

namespace Application.UseCases.Commands.TheaterHours.Create;

public class CreateTheaterHoursCommandHandler : ICommandHandler<CreateTheaterHoursCommand, int>
{
    private readonly ITheaterHoursRepository _theaterHoursRepository;
    private readonly ITheaterRepository _theaterRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateTheaterHoursCommand> _validator;

    public CreateTheaterHoursCommandHandler(
        ITheaterHoursRepository theaterHoursRepository,
        ITheaterRepository theaterRepository,
        IUnitOfWork unitOfWork,
        IValidator<CreateTheaterHoursCommand> validator )
    {
        _theaterHoursRepository = theaterHoursRepository;
        _theaterRepository = theaterRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<int> Handle( CreateTheaterHoursCommand command, CancellationToken cancellationToken )
    {
        var validationResult = await _validator.ValidateAsync( command, cancellationToken );
        if ( !validationResult.IsValid )
        {
            throw new ValidationException( validationResult.Errors );
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
