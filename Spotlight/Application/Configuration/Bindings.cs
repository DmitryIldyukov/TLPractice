using Application.UseCases.Commands.Author.Create;
using Application.UseCases.Commands.Author.Delete;
using Application.UseCases.Commands.Author.Update;
using Application.UseCases.Commands.Composition.Create;
using Application.UseCases.Commands.Play.Create;
using Application.UseCases.Commands.Theater.Create;
using Application.UseCases.Commands.Theater.Delete;
using Application.UseCases.Commands.Theater.Update;
using Application.UseCases.Commands.TheaterHours.Create;
using Application.UseCases.Queries.Author.GetById;
using Application.UseCases.Queries.Play.GetByFilter;
using Application.UseCases.Queries.Theater.GetById;
using Application.UseCases.Queries.Theater.GetTheaterById;
using Application.UseCases.Queries.TheaterHours.GetTheaterHoursByTheaterId;
using Application.UseCases.Queries.TheaterHours.GetTheaterHoursOnDayOfWeek;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration;

public static class Bindings
{
    public static IServiceCollection AddApplication( this IServiceCollection services )
    {
        services.AddTransient<IValidator<CreateAuthorCommand>, CreateAuthorCommandValidator>();
        services.AddTransient<IValidator<CreateCompositionCommand>, CreateCompositionCommandValidator>();
        services.AddTransient<IValidator<CreateTheaterHoursCommand>, CreateTheaterHoursCommandValidator>();
        services.AddTransient<IValidator<CreateCompositionCommand>, CreateCompositionCommandValidator>();
        services.AddTransient<IValidator<CreateTheaterCommand>, CreateTheaterCommandValidator>();
        services.AddTransient<IValidator<CreatePlayCommand>, CreatePlayCommandValidator>();

        services.AddTransient<IValidator<UpdateAuthorCommand>, UpdateAuthorCommandValidator>();
        services.AddTransient<IValidator<UpdateTheaterCommand>, UpdateTheaterCommandValidator>();

        services.AddTransient<IValidator<GetAuthorByIdQuery>, GetAuthorByIdQueryValidator>();
        services.AddTransient<IValidator<GetTheaterByIdQuery>, GetTheaterByIdQueryValidator>();
        services.AddTransient<IValidator<GetTheaterHoursByTheaterIdQuery>, GetTheaterHoursByTheaterIdQueryValidator>();
        services.AddTransient<IValidator<GetTheaterHoursOnDayOfWeekQuery>, GetTheaterHoursOnDayOfWeekQueryValidator>();
        services.AddTransient<IValidator<GetPlaysForPeriodDatesQuery>, GetPlaysForPeriodDatesQueryValidator>();

        services.AddTransient<IValidator<DeleteTheaterCommand>, DeleteTheaterCommandValidator>();
        services.AddTransient<IValidator<DeleteAuthorCommand>, DeleteAuthorCommandValidator>();

        services.AddMediatR( typeof( Bindings ).Assembly );

        return services;
    }
}
