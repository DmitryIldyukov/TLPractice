using FluentValidation;

namespace Application.UseCases.Commands.TheaterHours.Create;

public class CreateTheaterHoursCommandValidator : AbstractValidator<CreateTheaterHoursCommand>
{
    public CreateTheaterHoursCommandValidator()
    {
        RuleFor( command => command.TheaterId )
            .GreaterThan( 0 ).WithMessage( "Идентификатор театра должен быть положительным числом." );

        RuleFor( command => command.OpeningTime )
            .LessThan( command => command.ClosingTime ).WithMessage( "Время открытия должно быть раньше времени закрытия." );

        RuleFor( command => command.DayOfWeek )
            .IsInEnum().WithMessage( "Недопустимый день недели." );
    }
}