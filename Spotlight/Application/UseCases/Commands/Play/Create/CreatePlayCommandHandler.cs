using Application.Common.CQRS.Command;
using Application.Interfaces;
using Application.Interfaces.Repositories;

namespace Application.UseCases.Commands.Play.Create;

public class CreatePlayCommandHandler : ICommandHandler<CreatePlayCommand, int>
{
    private readonly IPlayRepository _playRepository;
    private readonly ITheaterRepository _theaterRepository;
    private readonly ICompositionRepository _compositionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePlayCommandHandler(
        IPlayRepository playRepository,
        IUnitOfWork unitOfWork,
        ITheaterRepository theaterRepository,
        ICompositionRepository compositionRepository )
    {
        _playRepository = playRepository;
        _unitOfWork = unitOfWork;
        _theaterRepository = theaterRepository;
        _compositionRepository = compositionRepository;
    }

    public async Task<int> Handle( CreatePlayCommand command, CancellationToken cancellationToken )
    {
        if ( string.IsNullOrEmpty( command.Name ) )
        {
            throw new ArgumentException( "Название представления не может быть пустым." );
        }

        if ( string.IsNullOrEmpty( command.Description ) )
        {
            throw new ArgumentException( "Описание представления не может быть пустым." );
        }

        if ( command.TicketPrice < 0 )
        {
            throw new ArgumentException( "Цена билета не может быть отрицательной." );
        }

        if ( command.StartDate >= command.EndDate )
        {
            throw new ArgumentException( "Дата начала должна быть раньше даты конца." );
        }

        if ( await _theaterRepository.GetById( command.TheaterId ) is null )
        {
            throw new ArgumentException( "Театр не найден." );
        }

        if ( await _compositionRepository.GetById( command.CompositionId ) is null )
        {
            throw new ArgumentException( "Композиция не найдена." );
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
