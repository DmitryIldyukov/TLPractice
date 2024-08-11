using Application.UseCases.Commands.TheaterHours.Create;
using Application.UseCases.Queries.TheaterHours.Dtos;
using Application.UseCases.Queries.TheaterHours.GetTheaterHoursByTheaterId;
using Application.UseCases.Queries.TheaterHours.GetTheaterHoursOnDayOfWeek;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos.TheaterHoures;

namespace WebAPI.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class TheaterHoursController : ControllerBase
{
    private readonly IMediator _mediator;

    public TheaterHoursController( IMediator mediator )
    {
        _mediator = mediator;
    }

    [HttpPost( "{theaterId:int}" )]
    [ProducesResponseType( typeof( int ), StatusCodes.Status200OK )]
    [ProducesResponseType( typeof( IReadOnlyList<string> ), StatusCodes.Status400BadRequest )]
    [ProducesResponseType( typeof( string ), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddTheaterHours( [FromRoute] int theaterId, [FromBody] TheaterHoursDto dto )
    {
        CreateTheaterHoursCommand command = new()
        {
            TheaterId = theaterId,
            DayOfWeek = dto.DayOfWeek,
            OpeningTime = dto.OpeningTime,
            ClosingTime = dto.ClosingTime,
        };

        try
        {
            int theaterHoursId = await _mediator.Send( command );

            return Ok( theaterHoursId );
        }
        catch ( FluentValidation.ValidationException e )
        {
            return BadRequest( e.Errors.Select( error => error.ErrorMessage ).ToList() );
        }
        catch ( NotFoundException e )
        {
            return NotFound( e.Message );
        }
    }

    [HttpGet( "[action]/{theaterId:int}" )]
    [ProducesResponseType( typeof( IReadOnlyList<GetTheaterHoursDto> ), StatusCodes.Status200OK )]
    [ProducesResponseType( typeof( IReadOnlyList<string> ), StatusCodes.Status400BadRequest )]
    [ProducesResponseType( StatusCodes.Status404NotFound )]
    public async Task<IActionResult> GetTheaterHourse( [FromRoute] int theaterId )
    {
        GetTheaterHoursByTheaterIdQuery query = new()
        {
            TheaterId = theaterId
        };

        try
        {
            IReadOnlyList<GetTheaterHoursDto> theaterHours = await _mediator.Send( query );

            return Ok( theaterHours );
        }
        catch ( FluentValidation.ValidationException e )
        {
            return BadRequest( e.Errors.Select( error => error.ErrorMessage ).ToList() );
        }
        catch ( NotFoundException e )
        {
            return NotFound( e.Message );
        }
    }

    [HttpGet( "[action]/{theaterId}/{dayOfWeek}" )]
    [ProducesResponseType( typeof( GetTheaterHoursDto ), StatusCodes.Status200OK )]
    [ProducesResponseType( typeof( IReadOnlyList<string> ), StatusCodes.Status400BadRequest )]
    [ProducesResponseType( StatusCodes.Status404NotFound )]
    public async Task<IActionResult> GetTheaterHoursOnDayOfWeek( [FromRoute] int theaterId, [FromRoute] DayOfWeek dayOfWeek )
    {
        GetTheaterHoursOnDayOfWeekQuery query = new()
        {
            TheaterId = theaterId,
            DayOfWeek = dayOfWeek
        };

        try
        {
            GetTheaterHoursDto theaterHours = await _mediator.Send( query );

            return Ok( theaterHours );
        }
        catch ( FluentValidation.ValidationException e )
        {
            return BadRequest( e.Errors.Select( error => error.ErrorMessage ).ToList() );
        }
        catch ( NotFoundException e )
        {
            return NotFound( e.Message );
        }
    }
}
