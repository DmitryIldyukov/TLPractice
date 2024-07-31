using Application.UseCases.Commands.Author.Create;
using Application.UseCases.Commands.Author.Delete;
using Application.UseCases.Commands.Author.Update;
using Application.UseCases.Queries.Author.Dtos;
using Application.UseCases.Queries.Author.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos.Author;
using WebAPI.Dtos.Theater;

namespace WebAPI.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorController( IMediator mediator )
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType( typeof( int ), StatusCodes.Status200OK )]
    [ProducesResponseType( typeof( string ), StatusCodes.Status400BadRequest )]
    public async Task<IActionResult> CreateAuthor( [FromBody] AuthorDto dto )
    {
        CreateAuthorCommand command = new()
        {
            Name = dto.Name,
            Birthday = dto.Birthday
        };

        try
        {
            int authorId = await _mediator.Send( command );

            return Ok( authorId );
        }
        catch ( ArgumentException e )
        {
            return BadRequest( e.Message );
        }
    }

    [HttpGet]
    [ProducesResponseType( typeof( IReadOnlyList<GetAuthorQueryDto> ), StatusCodes.Status200OK )]
    public async Task<IActionResult> GetAllAuthors()
    {
        GetAllAuthorQuery query = new();

        IReadOnlyList<GetAuthorQueryDto> response = await _mediator.Send( query );

        return Ok( response );
    }

    [HttpPut( "{authorId:int}" )]
    public async Task<IActionResult> UpdateAuthor( [FromRoute] int authorId, [FromBody] AuthorUpdateDto dto )
    {
        UpdateAuthorCommand command = new()
        {
            AuthorId = authorId,
            Name = dto.Name
        };

        try
        {
            await _mediator.Send( command );
            return Ok();
        }
        catch ( ArgumentException e )
        {
            return BadRequest( e.Message );
        }
    }

    [HttpDelete( "{authorId:int}" )]
    public async Task<IActionResult> DeleteAuthor( [FromRoute] int authorId )
    {
        DeleteAuthorCommand command = new()
        {
            AuthorId = authorId
        };

        await _mediator.Send( command );

        return NoContent();
    }
}
