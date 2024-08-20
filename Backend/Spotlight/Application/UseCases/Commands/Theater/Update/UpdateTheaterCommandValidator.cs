using FluentValidation;

namespace Application.UseCases.Commands.Theater.Update;

public class UpdateTheaterCommandValidator : AbstractValidator<UpdateTheaterCommand>
{
    public UpdateTheaterCommandValidator()
    {
        RuleFor( command => command.TheaterId )
            .GreaterThan( 0 ).WithMessage( "Идентификатор театра должен быть положительным числом." );

        RuleFor( command => command.Name )
            .NotEmpty().WithMessage( "Название не может быть пустым." );

        RuleFor( command => command.Description )
            .NotEmpty().WithMessage( "Описание не может быть пустым." );

        RuleFor( command => command.PhoneNumber )
            .NotEmpty().WithMessage( "Номер телефона для связи не может быть пустым." );
    }
}