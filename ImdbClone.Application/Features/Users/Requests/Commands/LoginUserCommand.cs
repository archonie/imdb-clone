using ImdbClone.Application.DTOs.User;
using ImdbClone.Application.Responses;
using MediatR;

namespace ImdbClone.Application.Features.Users.Requests.Commands;

public class LoginUserCommand : IRequest<LoginResponse>
{
    public LoginDto LoginDto { get; set; }
}