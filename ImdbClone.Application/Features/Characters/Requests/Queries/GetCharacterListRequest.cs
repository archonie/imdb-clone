using ImdbClone.Application.DTOs.Character;
using MediatR;

namespace ImdbClone.Application.Features.Characters.Requests.Queries;

public class GetCharacterListRequest : IRequest<List<CharacterDto>>
{
    
}