using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Actor;
using ImdbClone.Application.Features.Actors.Requests.Queries;
using ImdbClone.Domain;
using MediatR;

namespace ImdbClone.Application.Features.Actors.Handlers.Queries;

public class GetActorListRequestHandler : IRequestHandler<GetActorListRequest, List<ActorListDto>>
{
    private readonly IActorRepository _actorRepository;
    private readonly IMapper _mapper;

    public GetActorListRequestHandler(IActorRepository actorRepository, IMapper mapper)
    {
        _actorRepository = actorRepository;
        _mapper = mapper;
    }
    public async Task<List<ActorListDto>> Handle(GetActorListRequest request, CancellationToken cancellationToken)
    {
        var actors = await _actorRepository.GetAll();
        return _mapper.Map<List<ActorListDto>>(actors);
    }
}