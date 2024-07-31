using ImdbClone.Application.DTOs.Character;
using ImdbClone.Application.DTOs.Common;

namespace ImdbClone.Application.DTOs.Actor;

public class AddCharacterDto : BaseDto
{
    public int CharacterId { get; set; }
}