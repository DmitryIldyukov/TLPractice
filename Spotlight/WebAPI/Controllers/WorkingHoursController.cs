using Application.UseCases.Commands.WorkingHours.Create;
using Application.UseCases.Queries.WorkingHours.Dtos;
using Application.UseCases.Queries.WorkingHours.GetWorkingHoursByTheaterId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos.WorkingHoures;

namespace WebAPI.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class WorkingHoursController : ControllerBase
{
    private readonly IMediator _mediator;

    public WorkingHoursController( IMediator mediator )
    {
        _mediator = mediator;
    }

    [HttpPost( "{theaterId:int}" )]
    [ProducesResponseType( StatusCodes.Status200OK )]
    [ProducesResponseType( typeof( string ), StatusCodes.Status400BadRequest )]
    public async Task<IActionResult> AddWorkingHours( [FromRoute] int theaterId, [FromBody] WorkingHoursDto dto )
    {
        CreateWorkingHoursCommand command = new CreateWorkingHoursCommand()
        {
            TheaterId = theaterId,
            DayOfWeek = dto.DayOfWeek,
            OpeningTime = dto.OpeningTime,
            ClosingTime = dto.ClosingTime,
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

    [HttpGet( "[action]/{theaterId:int}" )]
    [ProducesResponseType( typeof( IReadOnlyList<GetWorkingHoursDto> ), StatusCodes.Status200OK )]
    [ProducesResponseType( typeof( string ), StatusCodes.Status400BadRequest )]
    public async Task<IActionResult> GetTheaterWorkingHourse( [FromRoute] int theaterId )
    {
        GetWorkingHoursByTheaterIdQuery query = new GetWorkingHoursByTheaterIdQuery()
        {
            TheaterId = theaterId
        };

        try
        {
            IReadOnlyList<GetWorkingHoursDto> workingHours = await _mediator.Send( query );

            return Ok( workingHours );
        }
        catch ( ArgumentException e )
        {
            return BadRequest( e.Message );
        }
    }
}
