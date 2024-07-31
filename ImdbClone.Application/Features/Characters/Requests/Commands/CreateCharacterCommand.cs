using ImdbClone.Application.DTOs.Character;
using ImdbClone.Application.Responses;
using MediatR;

namespace ImdbClone.Application.Features.Characters.Requests.Commands;

public class CreateCharacterCommand : IRequest<BaseCommandResponse>
{
    public CreateCharacterDto CharacterDto { get; set; }
}