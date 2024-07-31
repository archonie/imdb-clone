using ImdbClone.Application.DTOs.Common;
using ImdbClone.Application.DTOs.Film;

namespace ImdbClone.Application.DTOs.Character;
 
public class UpdateCharacterDto : BaseDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int ActorId { get; set; }
    public int FilmId { get; set; }
}