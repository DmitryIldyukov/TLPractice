using FluentValidation;

namespace Application.UseCases.Commands.Composition.Create;
public class CreateCompositionCommandValidator : AbstractValidator<CreateCompositionCommand>
{
    public CreateCompositionCommandValidator()
    {
        RuleFor( command => command.Name )
            .NotEmpty().WithMessage( "Название композиции не может быть пустым." );

        RuleFor( command => command.ShortDescription )
            .NotEmpty().WithMessage( "Краткое описание не может быть пустым." );

        RuleFor( command => command.HeroesInformation )
            .NotEmpty().WithMessage( "Информация о героях не может быть пустой." );

        RuleFor( command => command.AuthorId )
            .GreaterThan( 0 ).WithMessage( "Идентификатор автора должен быть положительным числом." );
    }
}