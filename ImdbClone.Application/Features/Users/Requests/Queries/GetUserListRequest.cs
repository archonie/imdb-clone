using ImdbClone.Application.DTOs.User;
using MediatR;

namespace ImdbClone.Application.Features.Users.Requests.Queries;

public class GetUserListRequest : IRequest<List<UserDto>>
{
    
}