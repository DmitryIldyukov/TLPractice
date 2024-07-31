using Application.Interfaces;
using Application.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Commands.Theater.Create;

public class CreateTheaterCommandHandler : IRequestHandler<CreateTheaterCommand>
{
    private readonly ITheaterRepository _theaterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTheaterCommandHandler( ITheaterRepository theaterRepository, IUnitOfWork unitOfWork )
    {
        _theaterRepository = theaterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle( CreateTheaterCommand command, CancellationToken cancellationToken )
    {
        if ( string.IsNullOrEmpty( command.Name ) )
        {
            throw new ArgumentException( "Название не может быть пустым." );
        }

        if ( string.IsNullOrEmpty( command.Address ) )
        {
            throw new ArgumentException( "Адрес не может быть пустым." );
        }

        if ( string.IsNullOrEmpty( command.PhoneNumber ) )
        {
            throw new ArgumentException( "Номер телефона для связи не может быть пустым." );
        }

        if ( string.IsNullOrEmpty( command.Description ) )
        {
            throw new ArgumentException( "Описание не может быть пустым." );
        }

        Domain.Entities.Theater theater = new Domain.Entities.Theater(
            command.Name,
            command.Address,
            command.FirstOpeningDate,
            command.Description,
            command.PhoneNumber
        );

        await _theaterRepository.Create( theater );

        await _unitOfWork.SaveChangesAsync( cancellationToken );

        return Unit.Value;
    }
}
