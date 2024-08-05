using FluentValidation;

namespace Application.UseCases.Commands.Theater.Create;

public class CreateTheaterCommandValidator : AbstractValidator<CreateTheaterCommand>
{
    public CreateTheaterCommandValidator()
    {
        RuleFor( command => command.Name )
            .NotEmpty().WithMessage( "Название не может быть пустым." );

        RuleFor( command => command.Address )
            .NotEmpty().WithMessage( "Адрес не может быть пустым." );

        RuleFor( command => command.PhoneNumber )
            .NotEmpty().WithMessage( "Номер телефона для связи не может быть пустым." );

        RuleFor( command => command.Description )
            .NotEmpty().WithMessage( "Описание не может быть пустым." );
    }
}