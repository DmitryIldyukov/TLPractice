using FluentValidation;

namespace Application.UseCases.Commands.Author.Delete;

public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
{
    public DeleteAuthorCommandValidator()
    {
        RuleFor( command => command.AuthorId )
            .GreaterThan( 0 ).WithMessage( "Идентификатор автора должен быть положительным числом." );
    }
}