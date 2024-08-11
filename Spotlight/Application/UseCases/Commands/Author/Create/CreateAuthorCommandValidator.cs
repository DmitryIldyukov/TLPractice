using FluentValidation;

namespace Application.UseCases.Commands.Author.Create;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor( command => command.Name )
            .NotEmpty().WithMessage( "Имя автора не может быть пустым." );

        RuleFor( command => command.Birthday )
            .NotEmpty().WithMessage( "Дата рождения не может быть пустой." )
            .Must( birthday =>
            {
                if ( birthday == DateTime.MinValue )
                {
                    return false;
                }

                int currentAge = DateTime.Now.Year - birthday.Year;

                if ( birthday.Date > DateTime.Now.AddYears( -currentAge ) )
                {
                    currentAge--;
                }

                return currentAge >= 10;
            } ).WithMessage( "Минимальный возраст автора 10 лет." );
    }
}
