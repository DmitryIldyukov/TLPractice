﻿using Application.UseCases.Commands.Play.Create;
using Application.UseCases.Queries.Play.Dtos;
using Application.UseCases.Queries.Play.GetByFilter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos.Play;

namespace WebAPI.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class PlayController : ControllerBase
{
    private readonly IMediator _mediator;

    public PlayController( IMediator mediator )
    {
        _mediator = mediator;
    }

    [HttpPost( "[action]" )]
    [ProducesResponseType( typeof( int ), StatusCodes.Status200OK )]
    [ProducesResponseType( typeof( string ), StatusCodes.Status400BadRequest )]
    public async Task<IActionResult> CreatePlay( [FromBody] PlayDto dto )
    {
        CreatePlayCommand command = new CreatePlayCommand()
        {
            Name = dto.Name,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            TicketPrice = dto.TicketPrice,
            TheaterId = dto.TheaterId,
            CompositionId = dto.CompositionId,
            Description = dto.Description,
        };

        try
        {
            int playId = await _mediator.Send( command );

            return Ok( playId );
        }
        catch ( ArgumentException e )
        {
            return BadRequest( e.Message );
        }
    }

    [HttpPost( "[action]" )]
    [ProducesResponseType( typeof( IReadOnlyList<GetPlayDto> ), StatusCodes.Status200OK )]
    [ProducesResponseType( typeof( string ), StatusCodes.Status400BadRequest )]
    public async Task<IActionResult> GetPlaysForPeriodDates( [FromBody] PlayPeriodFilter filter )
    {
        GetPlaysForPeriodDatesQuery query = new()
        {
            StartDate = filter.StartDate,
            EndDate = filter.EndDate,
        };

        try
        {
            IReadOnlyList<GetPlayDto> availablePlays = await _mediator.Send( query );
            return Ok( availablePlays );
        }
        catch ( ArgumentException e )
        {
            return BadRequest( e.Message );
        }
    }
}
