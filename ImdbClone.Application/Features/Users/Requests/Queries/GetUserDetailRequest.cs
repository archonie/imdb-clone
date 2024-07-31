using ImdbClone.Application.DTOs.User;
using MediatR;

namespace ImdbClone.Application.Features.Users.Requests.Queries;

public class GetUserDetailRequest : IRequest<UserDto>
{
    public int Id { get; set; }
}