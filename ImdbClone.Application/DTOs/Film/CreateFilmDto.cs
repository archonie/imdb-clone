using ImdbClone.Application.DTOs.Common;
using ImdbClone.Application.DTOs.Director;

namespace ImdbClone.Application.DTOs.Film;

public class CreateFilmDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int DirectorId { get; set; }
}