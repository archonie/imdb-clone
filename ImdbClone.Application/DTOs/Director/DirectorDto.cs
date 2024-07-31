using ImdbClone.Application.DTOs.Common;
using ImdbClone.Application.DTOs.Film;

namespace ImdbClone.Application.DTOs.Director;

public class DirectorDto : BaseDto
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<FilmListDto> Films { get; set; }
}