using ImdbClone.Application.DTOs.Director;
using ImdbClone.Application.DTOs.User;
using ImdbClone.Application.Features.Users.Requests.Commands;
using ImdbClone.Application.Features.Users.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ImdbClone.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationUsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public ApplicationUsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<DirectorDto>>> Get()
    {
        var films = await _mediator.Send(new GetUserListRequest());
        return Ok(films);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> Get(int id)
    {
        var film = await _mediator.Send(new GetUserDetailRequest { Id = id });
        return Ok(film);
    }

    [HttpPost("register")]
    public async Task<ActionResult> Post([FromBody] RegisterUserDto user)
    {
        var command = new CreateUserCommand { UserDto = user };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
    [HttpPost("login")]
    
    public async Task<ActionResult> Post([FromBody] LoginDto user)
    {
        var command = new LoginUserCommand { LoginDto = user };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateUserDto user)
    {
        user.Id = id;
        var command = new UpdateUserCommand { UserDto = user };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("updatewatchedfilms/{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateWatchedFilmsDto user)
    {
        var command = new UpdateUserCommand { UpdateWatchedFilmsDto = user };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteUserCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}