using FluentValidation;

namespace Application.UseCases.Commands.Author.Update;

public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor( command => command.AuthorId )
            .GreaterThan( 0 ).WithMessage( "Идентификатор автора должен быть положительным числом." );

        RuleFor( command => command.Name )
            .NotEmpty().WithMessage( "Имя автора не может быть пустым." );
    }
}