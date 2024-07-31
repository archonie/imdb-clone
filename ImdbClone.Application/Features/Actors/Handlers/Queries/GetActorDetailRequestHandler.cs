using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Actor;
using ImdbClone.Application.Features.Actors.Requests.Queries;
using MediatR;

namespace ImdbClone.Application.Features.Actors.Handlers.Queries;

public class GetActorDetailRequestHandler : IRequestHandler<GetActorDetailRequest, ActorDto>
{
    private readonly IActorRepository _actorRepository;
    private readonly IMapper _mapper;

    public GetActorDetailRequestHandler(IActorRepository actorRepository, IMapper mapper)
    {
        _actorRepository = actorRepository;
        _mapper = mapper;
    }
    public async Task<ActorDto> Handle(GetActorDetailRequest request, CancellationToken cancellationToken)
    {
        var actor = await _actorRepository.GetActorWithCharacters(request.Id);
        return _mapper.Map<ActorDto>(actor);
    }
}