using ImdbClone.Application.DTOs.Actor;
using ImdbClone.Application.Responses;
using MediatR;

namespace ImdbClone.Application.Features.Actors.Requests.Commands;

public class CreateActorCommand : IRequest<BaseCommandResponse>
{
    public CreateActorDto ActorDto { get; set; }
}