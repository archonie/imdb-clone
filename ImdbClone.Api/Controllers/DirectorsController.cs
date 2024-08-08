using ImdbClone.Application.DTOs.Director;
using ImdbClone.Application.Features.Directors.Requests.Commands;
using ImdbClone.Application.Features.Directors.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ImdbClone.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class DirectorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DirectorsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<DirectorDto>>> Get()
    {
        var films = await _mediator.Send(new GetDirectorListRequest());
        return Ok(films);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<DirectorDto>> Get(int id)
    {
        var film = await _mediator.Send(new GetDirectorDetailRequest{Id = id});
        return Ok(film);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateDirectorDto director)
    {
        var command = new CreateDirectorCommand{DirectorDto = director};
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateDirectorDto updateDirectorDto)
    {
        var command = new UpdateDirectorCommand{DirectorDto = updateDirectorDto};
        await _mediator.Send(command);
        return NoContent();
    }
    [HttpPut("{id}/updatefilms")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateDirectorFilmsDto updateDirectorDto)
    {
        var command = new UpdateDirectorCommand{UpdateDirectorFilmsDto = updateDirectorDto};
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDirectorCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
    
}