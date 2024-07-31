using ImdbClone.Application.DTOs.Film;
using ImdbClone.Application.Features.Films.Requests.Commands;
using ImdbClone.Application.Features.Films.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ImdbClone.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmsController : ControllerBase
{
    private readonly IMediator _mediator;

    public FilmsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<FilmDto>>> Get()
    {
        var films = await _mediator.Send(new GetFilmListRequest());
        return Ok(films);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<FilmDto>> Get(int id)
    {
        var film = await _mediator.Send(new GetFilmDetailRequest{Id = id});
        return Ok(film);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateFilmDto film)
    {
        var command = new CreateFilmCommand { FilmDto = film };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateFilmDto film)
    {
        var command = new UpdateFilmCommand { FilmDto = film };
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpPut("updatedirector/{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateFilmDirectorDto film)
    {
        var command = new UpdateFilmCommand { FilmDirectorDto = film };
        await _mediator.Send(command);
        return NoContent();
    }
    [HttpPut("updateuserlist/{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateUserListDto film)
    {
        var command = new UpdateFilmCommand { UserListDto = film };
        await _mediator.Send(command);
        return NoContent();
    }
    [HttpPut("updatecharacterlist/{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateFilmCharactersListDto film)
    {
        var command = new UpdateFilmCommand { UpdateFilmCharactersListDto = film };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteFilmCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
    
}