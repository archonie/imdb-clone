using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Character;
using ImdbClone.Application.Features.Characters.Requests.Queries;
using MediatR;

namespace ImdbClone.Application.Features.Characters.Handlers.Queries;

public class GetCharacterDetailRequestHandler : IRequestHandler<GetCharacterDetailRequest, CharacterDto>
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IMapper _mapper;

    public GetCharacterDetailRequestHandler(ICharacterRepository characterRepository, IMapper mapper)
    {
        _characterRepository = characterRepository;
        _mapper = mapper;
    }
    public async Task<CharacterDto> Handle(GetCharacterDetailRequest request, CancellationToken cancellationToken)
    {
        var character = await _characterRepository.Get(request.Id);
        return _mapper.Map<CharacterDto>(character);
    }
}