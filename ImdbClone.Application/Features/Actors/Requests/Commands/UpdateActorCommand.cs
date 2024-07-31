using ImdbClone.Application.DTOs.Actor;
using MediatR;

namespace ImdbClone.Application.Features.Actors.Requests.Commands;

public class UpdateActorCommand : IRequest<Unit>
{
    public UpdateActorDto ActorDto { get; set; }
    public AddCharacterDto AddCharacterDto { get; set; }
}