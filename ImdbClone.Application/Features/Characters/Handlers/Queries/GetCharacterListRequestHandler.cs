using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Character;
using ImdbClone.Application.Features.Characters.Requests.Queries;
using MediatR;

namespace ImdbClone.Application.Features.Characters.Handlers.Queries;

public class GetCharacterListRequestHandler : IRequestHandler<GetCharacterListRequest, List<CharacterDto>>
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IMapper _mapper;

    public GetCharacterListRequestHandler(ICharacterRepository characterRepository, IMapper mapper)
    {
        _characterRepository = characterRepository;
        _mapper = mapper;
    }
    public async Task<List<CharacterDto>> Handle(GetCharacterListRequest request, CancellationToken cancellationToken)
    {
        var characters = await _characterRepository.GetAll();
        return _mapper.Map<List<CharacterDto>>(characters);
    }
}