using MediatR;

namespace ImdbClone.Application.Features.Actors.Requests.Commands;

public class DeleteActorCommand : IRequest<Unit>
{
    public int Id { get; set; }
}