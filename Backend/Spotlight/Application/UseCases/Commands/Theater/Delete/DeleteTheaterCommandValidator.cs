using FluentValidation;

namespace Application.UseCases.Commands.Theater.Delete;

public class DeleteTheaterCommandValidator : AbstractValidator<DeleteTheaterCommand>
{
    public DeleteTheaterCommandValidator()
    {
        RuleFor( command => command.TheaterId )
            .GreaterThan( 0 ).WithMessage( "Идентификатор театра должен быть положительным числом." );
    }
}