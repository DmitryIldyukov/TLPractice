﻿namespace Application.UseCases.Queries.Author.Dtos;

public class GetAuthorQueryDto
{
    public int AuthorId { get; init; }
    public string Name { get; init; }
    public DateTime Birthday { get; init; }
}
