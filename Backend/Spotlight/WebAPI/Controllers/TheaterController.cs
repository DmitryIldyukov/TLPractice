﻿using Application.UseCases.Commands.Theater.Create;
using Application.UseCases.Commands.Theater.Delete;
using Application.UseCases.Commands.Theater.Update;
using Application.UseCases.Queries.Theater.Dtos;
using Application.UseCases.Queries.Theater.GetAll;
using Application.UseCases.Queries.Theater.GetById;
using Domain.Exceptions;
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
    [ProducesResponseType( typeof( int ), StatusCodes.Status201Created )]
    [ProducesResponseType( typeof( IReadOnlyList<string> ), StatusCodes.Status400BadRequest )]
    public async Task<IActionResult> CreateTheater( [FromBody] TheaterDto dto )
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
        catch ( FluentValidation.ValidationException e )
        {
            return BadRequest( e.Errors.Select( error => error.ErrorMessage ).ToList() );
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
    [ProducesResponseType( typeof( IReadOnlyList<string> ), StatusCodes.Status400BadRequest )]
    [ProducesResponseType( typeof( string ), StatusCodes.Status404NotFound )]
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
        catch ( FluentValidation.ValidationException e )
        {
            return BadRequest( e.Errors.Select( error => error.ErrorMessage ).ToList() );
        }
        catch ( NotFoundException e )
        {
            return NotFound( e.Message );
        }
    }

    [HttpPut( "{theaterId:int}" )]
    [ProducesResponseType( StatusCodes.Status200OK )]
    [ProducesResponseType( typeof( string ), StatusCodes.Status404NotFound )]
    [ProducesResponseType( typeof( IReadOnlyList<string> ), StatusCodes.Status400BadRequest )]
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
        catch ( NotFoundException e )
        {
            return NotFound( e.Message );
        }
        catch ( FluentValidation.ValidationException e )
        {
            return BadRequest( e.Errors.Select( error => error.ErrorMessage ).ToList() );
        }
    }

    [HttpDelete( "{theaterId:int}" )]
    [ProducesResponseType( StatusCodes.Status204NoContent )]
    [ProducesResponseType( typeof( IReadOnlyList<string> ), StatusCodes.Status400BadRequest )]
    public async Task<IActionResult> DeleteTheater( [FromRoute] int theaterId )
    {
        DeleteTheaterCommand command = new()
        {
            TheaterId = theaterId
        };

        try
        {
            await _mediator.Send( command );

            return NoContent();
        }
        catch ( FluentValidation.ValidationException e )
        {
            return BadRequest( e.Errors.Select( error => error.ErrorMessage ).ToList() );
        }
    }
}
