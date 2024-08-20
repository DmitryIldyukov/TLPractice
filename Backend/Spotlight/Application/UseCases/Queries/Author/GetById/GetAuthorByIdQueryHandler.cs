using Application.Common.CQRS.Query;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.UseCases.Queries.Author.Dtos;
using Domain.Exceptions;
using FluentValidation;

namespace Application.UseCases.Queries.Author.GetById;

public class GetAuthorByIdQueryHandler : IQueryHandler<GetAuthorByIdQuery, GetAuthorQueryDto>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<GetAuthorByIdQuery> _validator;

    public GetAuthorByIdQueryHandler(
        IAuthorRepository authorRepository,
        IUnitOfWork unitOfWork,
        IValidator<GetAuthorByIdQuery> validator )
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<GetAuthorQueryDto> Handle( GetAuthorByIdQuery query, CancellationToken cancellationToken )
    {
        var validationResult = await _validator.ValidateAsync( query, cancellationToken );
        if ( !validationResult.IsValid )
        {
            throw new ValidationException( validationResult.Errors );
        }

        Domain.Entities.Author author = await _authorRepository.GetById( query.AuthorId )
            ?? throw new NotFoundException( "Автор не найден." );

        GetAuthorQueryDto response = new()
        {
            AuthorId = author.AuthorId,
            Name = author.Name,
            Birthday = author.Birthday,
        };

        return response;
    }
}
