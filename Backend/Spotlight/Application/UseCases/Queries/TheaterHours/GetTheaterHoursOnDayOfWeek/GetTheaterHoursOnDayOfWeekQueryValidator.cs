using FluentValidation;

namespace Application.UseCases.Queries.TheaterHours.GetTheaterHoursOnDayOfWeek;

public class GetTheaterHoursOnDayOfWeekQueryValidator : AbstractValidator<GetTheaterHoursOnDayOfWeekQuery>
{
    public GetTheaterHoursOnDayOfWeekQueryValidator()
    {
        RuleFor( query => query.TheaterId )
            .GreaterThan( 0 ).WithMessage( "Идентификатор театра должен быть положительным числом." );

        RuleFor( query => query.DayOfWeek )
            .IsInEnum().WithMessage( "День недели должен быть допустимым значением." );
    }
}