using ImdbClone.Application.DTOs.Character;
using ImdbClone.Application.DTOs.Common;

namespace ImdbClone.Application.DTOs.Actor;

public class ActorDto : BaseDto
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<CharacterDto> Characters { get; set; }
}