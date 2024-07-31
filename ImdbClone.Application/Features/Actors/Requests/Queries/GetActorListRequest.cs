using ImdbClone.Application.DTOs.Actor;
using MediatR;

namespace ImdbClone.Application.Features.Actors.Requests.Queries;

public class GetActorListRequest : IRequest<List<ActorListDto>>
{
    
}