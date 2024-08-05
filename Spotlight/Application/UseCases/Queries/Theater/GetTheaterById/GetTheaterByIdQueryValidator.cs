using Application.UseCases.Queries.Theater.GetById;
using FluentValidation;

namespace Application.UseCases.Queries.Theater.GetTheaterById;

public class GetTheaterByIdQueryValidator : AbstractValidator<GetTheaterByIdQuery>
{
    public GetTheaterByIdQueryValidator()
    {
        RuleFor( query => query.TheaterId )
            .GreaterThan( 0 ).WithMessage( "Идентификатор театра должен быть положительным числом." );
    }
}