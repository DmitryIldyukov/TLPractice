using Application.UseCases.Commands.Play.Create;
using FluentValidation;

public class CreatePlayCommandValidator : AbstractValidator<CreatePlayCommand>
{
    public CreatePlayCommandValidator()
    {
        RuleFor( command => command.Name )
            .NotEmpty().WithMessage( "Название представления не может быть пустым." );

        RuleFor( command => command.Description )
            .NotEmpty().WithMessage( "Описание представления не может быть пустым." );

        RuleFor( command => command.TicketPrice )
            .GreaterThanOrEqualTo( 0 ).WithMessage( "Цена билета не может быть отрицательной." );

        RuleFor( command => command.StartDate )
            .LessThan( command => command.EndDate ).WithMessage( "Дата начала должна быть раньше даты конца." );
    }
}
