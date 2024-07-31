using Application.UseCases.Commands.Composition.Create;
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
    [ProducesResponseType( StatusCodes.Status200OK )]
    [ProducesResponseType( typeof( string ), StatusCodes.Status400BadRequest )]
    public async Task<IActionResult> CreateComposition( [FromBody] CompositionDto dto )
    {
        CreateCompositionCommand command = new CreateCompositionCommand()
        {
            Name = dto.Name,
            ShortDescription = dto.ShortDescription,
            HeroesInformation = dto.HeroesInformation,
            AuthorId = dto.AuthorId,
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
}
