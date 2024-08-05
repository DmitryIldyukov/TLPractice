using FluentValidation;

namespace Application.UseCases.Queries.Play.GetByFilter;

public class GetPlaysForPeriodDatesQueryValidator : AbstractValidator<GetPlaysForPeriodDatesQuery>
{
    public GetPlaysForPeriodDatesQueryValidator()
    {
        RuleFor( query => query.StartDate )
            .NotEmpty().WithMessage( "Дата начала не может быть пустой." );

        RuleFor( query => query.EndDate )
            .NotEmpty().WithMessage( "Дата окончания не может быть пустой." )
            .GreaterThan( query => query.StartDate ).WithMessage( "Дата начала не может быть позже даты окончания." );
    }
}