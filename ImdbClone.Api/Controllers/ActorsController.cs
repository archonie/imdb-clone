using ImdbClone.Application.DTOs.Actor;
using ImdbClone.Application.Features.Actors.Requests.Commands;
using ImdbClone.Application.Features.Actors.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ImdbClone.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ActorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ActorsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ActorDto>>> Get()
    {
        var actors = await _mediator.Send(new GetActorListRequest());
        return Ok(actors);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ActorDto>> Get(int id)
    {
        var actor = await _mediator.Send(new GetActorDetailRequest{Id = id});
        return Ok(actor);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateActorDto actor)
    {
        var command = new CreateActorCommand { ActorDto = actor };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateActorDto actor)
    {
        actor.Id = id; 
        var command = new UpdateActorCommand { ActorDto = actor };
        await _mediator.Send(command);
        return NoContent();
    }
    [HttpPut("{id}/addcharacter")]
    public async Task<ActionResult> Put([FromBody] AddCharacterDto actor)
    {
        var command = new UpdateActorCommand{AddCharacterDto = actor};
        await _mediator.Send(command);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteActorCommand{Id = id};
        await _mediator.Send(command);
        return NoContent();
    }
    

}