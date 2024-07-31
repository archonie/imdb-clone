using ImdbClone.Application.DTOs.Character;
using MediatR;

namespace ImdbClone.Application.Features.Characters.Requests.Queries;

public class GetCharacterDetailRequest : IRequest<CharacterDto>
{
    public int Id { get; set; }
}