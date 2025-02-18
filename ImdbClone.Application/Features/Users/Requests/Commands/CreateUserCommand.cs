using ImdbClone.Application.DTOs.User;
using ImdbClone.Application.Responses;
using MediatR;

namespace ImdbClone.Application.Features.Users.Requests.Commands;

public class CreateUserCommand : IRequest<RegisterResponse> 
{
    public RegisterUserDto UserDto { get; set; }
}