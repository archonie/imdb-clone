using MediatR;

namespace ImdbClone.Application.Features.Users.Requests.Commands;

public class DeleteUserCommand : IRequest<Unit>
{
    public int Id { get; set; }
}