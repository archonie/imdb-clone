using ImdbClone.Application.DTOs.Actor;
using MediatR;

namespace ImdbClone.Application.Features.Actors.Requests.Queries;

public class GetActorDetailRequest : IRequest<ActorDto>
{
    public int Id { get; set; }
    
}