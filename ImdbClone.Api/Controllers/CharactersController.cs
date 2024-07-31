using ImdbClone.Application.DTOs.Character;
using ImdbClone.Application.Features.Characters.Requests.Commands;
using ImdbClone.Application.Features.Characters.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ImdbClone.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharactersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CharactersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<CharacterDto>>> Get()
    {
        var films = await _mediator.Send(new GetCharacterListRequest());
        return Ok(films);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CharacterDto>> Get(int id)
    {
        var film = await _mediator.Send(new GetCharacterDetailRequest{Id = id});
        return Ok(film);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateCharacterDto character)
    {
        var command = new CreateCharacterCommand{CharacterDto = character};
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateCharacterDto character)
    {
        var command = new UpdateCharacterCommand{CharacterDto = character};
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCharacterCommand{Id = id};
        await _mediator.Send(command);
        return NoContent();
    }


    
    
}