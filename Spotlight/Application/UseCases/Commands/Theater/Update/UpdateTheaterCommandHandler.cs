using Application.Common.CQRS.Command;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Exceptions;
using MediatR;

namespace Application.UseCases.Commands.Theater.Update;

public class UpdateTheaterCommandHandler : ICommandHandler<UpdateTheaterCommand, Unit>
{
    private readonly ITheaterRepository _theaterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTheaterCommandHandler( ITheaterRepository theaterRepository, IUnitOfWork unitOfWork )
    {
        _theaterRepository = theaterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle( UpdateTheaterCommand command, CancellationToken cancellationToken )
    {
        if ( string.IsNullOrEmpty( command.Name ) )
        {
            throw new ArgumentException( "Название не может быть пустым." );
        }

        if ( string.IsNullOrEmpty( command.Description ) )
        {
            throw new ArgumentException( "Описание не может быть пустым." );
        }

        if ( string.IsNullOrEmpty( command.PhoneNumber ) )
        {
            throw new ArgumentException( "Номер телефона для связи не может быть пустым." );
        }

        Domain.Entities.Theater theater = await _theaterRepository.GetById( command.TheaterId ) 
            ?? throw new NotFoundException( "Театр не найден." );

        theater.Name = command.Name;
        theater.Description = command.Description;
        theater.PhoneNumber = command.PhoneNumber;

        await _unitOfWork.SaveChangesAsync( cancellationToken );

        return Unit.Value;
    }
}
