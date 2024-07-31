using ImdbClone.Application.DTOs.User;
using MediatR;

namespace ImdbClone.Application.Features.Users.Requests.Commands;

public class UpdateUserCommand : IRequest<Unit>
{
    public UpdateUserDto UserDto { get; set; }
    public UpdateWatchedFilmsDto UpdateWatchedFilmsDto { get; set; }
}