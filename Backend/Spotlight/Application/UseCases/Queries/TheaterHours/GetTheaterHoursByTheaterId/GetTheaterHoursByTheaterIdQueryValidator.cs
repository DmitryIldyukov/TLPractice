using FluentValidation;

namespace Application.UseCases.Queries.TheaterHours.GetTheaterHoursByTheaterId;

public class GetTheaterHoursByTheaterIdQueryValidator : AbstractValidator<GetTheaterHoursByTheaterIdQuery>
{
    public GetTheaterHoursByTheaterIdQueryValidator()
    {
        RuleFor( query => query.TheaterId )
            .GreaterThan( 0 ).WithMessage( "Идентификатор театра должен быть положительным числом." );
    }
}