using ImdbClone.Application.DTOs.Character;
using MediatR;

namespace ImdbClone.Application.Features.Characters.Requests.Commands;

public class UpdateCharacterCommand : IRequest<Unit>
{
    public UpdateCharacterDto CharacterDto { get; set; }
}