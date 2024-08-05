using FluentValidation;

namespace Application.UseCases.Queries.Author.GetById;

public class GetAuthorByIdQueryValidator : AbstractValidator<GetAuthorByIdQuery>
{
    public GetAuthorByIdQueryValidator()
    {
        RuleFor( query => query.AuthorId )
            .GreaterThan( 0 ).WithMessage( "Идентификатор автора должен быть положительным числом." );
    }
}
