using Application.UseCases.Commands.Theater.Create;
using Application.UseCases.Commands.Theater.Delete;
using Application.UseCases.Commands.Theater.Update;
using Application.UseCases.Queries.Theater.Dtos;
using Application.UseCases.Queries.Theater.GetAll;
using Application.UseCases.Queries.Theater.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos.Theater;

namespace WebAPI.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class TheaterController : ControllerBase
{
    private readonly IMediator _mediator;

    public TheaterController( IMediator mediator )
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType( typeof( int ), StatusCodes.Status200OK )]
    [ProducesResponseType( typeof( string ), StatusCodes.Status400BadRequest )]
    public async Task<IActionResult> CreateTheater( [FromBody] TheaterDto dto, CancellationToken cancellationToken )
    {
        CreateTheaterCommand command = new()
        {
            Name = dto.Name,
            Description = dto.Description,
            FirstOpeningDate = dto.FirstOpeningDate,
            Address = dto.Address,
            PhoneNumber = dto.PhoneNumber
        };

        try
        {
            int theaterId = await _mediator.Send( command );

            return Created( nameof( CreateTheater ), theaterId );
        }
        catch ( ArgumentException e )
        {
            return BadRequest( e.Message );
        }
    }

    [HttpGet]
    [ProducesResponseType( typeof( IReadOnlyList<GetTheaterDto> ), StatusCodes.Status200OK )]
    [ProducesResponseType( typeof( string ), StatusCodes.Status400BadRequest )]
    public async Task<IActionResult> GetAllTheaters()
    {
        GetAllTheaterQuery query = new();

        IReadOnlyList<GetTheaterDto> theaters = await _mediator.Send( query );

        return Ok( theaters );
    }

    [HttpGet( "{theaterId:int}" )]
    [ProducesResponseType( typeof( GetTheaterDto ), StatusCodes.Status200OK )]
    [ProducesResponseType( typeof( string ), StatusCodes.Status400BadRequest )]
    public async Task<IActionResult> GetTheaterById( [FromRoute] int theaterId )
    {
        GetTheaterByIdQuery query = new()
        {
            TheaterId = theaterId
        };

        try
        {
            GetTheaterDto theater = await _mediator.Send( query );

            return Ok( theater );
        }
        catch ( ArgumentException e )
        {
            return NotFound( e.Message );
        }
    }

    [HttpPut( "{theaterId:int}" )]
    [ProducesResponseType( StatusCodes.Status200OK )]
    [ProducesResponseType( typeof( string ), StatusCodes.Status400BadRequest )]
    public async Task<IActionResult> UpdateTheater( [FromRoute] int theaterId, [FromBody] TheaterUpdateDto dto )
    {
        UpdateTheaterCommand command = new()
        {
            TheaterId = theaterId,
            Name = dto.Name,
            Description = dto.Description,
            PhoneNumber = dto.PhoneNumber,
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

    [HttpDelete( "{theaterId:int}" )]
    [ProducesResponseType( StatusCodes.Status200OK )]
    public async Task<IActionResult> DeleteTheater( [FromRoute] int theaterId )
    {
        DeleteTheaterCommand command = new()
        {
            TheaterId = theaterId
        };

        await _mediator.Send( command );

        return NoContent();
    }
}
