using ImdbClone.Application.DTOs.Character;
using ImdbClone.Application.DTOs.Common;

namespace ImdbClone.Application.DTOs.Film;

public class UpdateFilmCharactersListDto : BaseDto
{
    public CharacterDto CharacterDto { get; set; }
}