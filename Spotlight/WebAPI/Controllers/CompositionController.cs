using Application.UseCases.Commands.Composition.Create;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos.Composition;

namespace WebAPI.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class CompositionController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompositionController( IMediator mediator )
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType( typeof( int ), StatusCodes.Status200OK )]
    [ProducesResponseType( typeof( string ), StatusCodes.Status404NotFound )]
    [ProducesResponseType( typeof( IReadOnlyList<string> ), StatusCodes.Status400BadRequest )]
    public async Task<IActionResult> CreateComposition( [FromBody] CompositionDto dto )
    {
        CreateCompositionCommand command = new()
        {
            Name = dto.Name,
            ShortDescription = dto.ShortDescription,
            HeroesInformation = dto.HeroesInformation,
            AuthorId = dto.AuthorId,
        };

        try
        {
            int compositionId = await _mediator.Send( command );

            return Ok( compositionId );
        }
        catch ( NotFoundException e )
        {
            return NotFound( e.Message );
        }
        catch ( FluentValidation.ValidationException e )
        {
            return BadRequest( e.Errors.Select( error => error.ErrorMessage ).ToList() );
        }
    }
}
