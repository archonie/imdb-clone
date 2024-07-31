using ImdbClone.Application.DTOs.Character;
using ImdbClone.Application.DTOs.Common;
using ImdbClone.Application.DTOs.Director;
using ImdbClone.Application.DTOs.User;

namespace ImdbClone.Application.DTOs.Film;

public class FilmDto : BaseDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Rate { get; set; }
    public List<UserDto> Users { get; set; }
    public List<CharacterDto> Characters { get; set; }
    public int DirectorId { get; set; }
}