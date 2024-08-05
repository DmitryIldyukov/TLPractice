using System.ComponentModel.DataAnnotations;
using Application.Common.CQRS.Command;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Exceptions;
using FluentValidation;

namespace Application.UseCases.Commands.Play.Create;

public class CreatePlayCommandHandler : ICommandHandler<CreatePlayCommand, int>
{
    private readonly IPlayRepository _playRepository;
    private readonly ITheaterRepository _theaterRepository;
    private readonly ICompositionRepository _compositionRepository;
    private readonly ITheaterHoursRepository _theaterHoursRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreatePlayCommand> _validator;

    public CreatePlayCommandHandler(
        IPlayRepository playRepository,
        IUnitOfWork unitOfWork,
        ITheaterRepository theaterRepository,
        ICompositionRepository compositionRepository,
        ITheaterHoursRepository theaterHoursRepository,
        IValidator<CreatePlayCommand> validator )
    {
        _playRepository = playRepository;
        _unitOfWork = unitOfWork;
        _theaterRepository = theaterRepository;
        _compositionRepository = compositionRepository;
        _theaterHoursRepository = theaterHoursRepository;
        _validator = validator;
    }

    public async Task<int> Handle( CreatePlayCommand command, CancellationToken cancellationToken )
    {
        var validationResult = await _validator.ValidateAsync( command, cancellationToken );

        if ( !validationResult.IsValid )
        {
            throw new FluentValidation.ValidationException( validationResult.Errors );
        }

        if ( await _theaterRepository.GetById( command.TheaterId ) is null )
        {
            throw new NotFoundException( "Театр не найден." );
        }

        if ( await _compositionRepository.GetById( command.CompositionId ) is null )
        {
            throw new NotFoundException( "Композиция не найдена." );
        }

        Domain.Entities.TheaterHours theaterHoursOnDayOfWeek = await _theaterHoursRepository.GetOnDayOfWeek( command.TheaterId, command.StartDate.DayOfWeek )
            ?? throw new ArgumentException( "Невозможно добавить представление. Театр в этот день не работает." );

        TimeSpan startTime = command.StartDate.TimeOfDay;
        TimeSpan endTime = command.EndDate.TimeOfDay;
        TimeSpan openingTime = theaterHoursOnDayOfWeek.OpeningTime;
        TimeSpan closingTime = theaterHoursOnDayOfWeek.ClosingTime;

        if ( startTime < openingTime || endTime > closingTime )
        {
            throw new ArgumentException( "Невозможно добавить представление. Театр в это время не работает." );
        }

        Domain.Entities.Play play = new Domain.Entities.Play(
            command.Name,
            command.StartDate,
            command.EndDate,
            command.TicketPrice,
            command.Description,
            command.TheaterId,
            command.CompositionId
        );

        await _playRepository.Create( play );

        await _unitOfWork.SaveChangesAsync();

        return play.PlayId;
    }
}
