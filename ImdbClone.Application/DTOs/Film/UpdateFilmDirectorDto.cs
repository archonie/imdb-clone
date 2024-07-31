using ImdbClone.Application.DTOs.Common;
using ImdbClone.Application.DTOs.Director;

namespace ImdbClone.Application.DTOs.Film;

public class UpdateFilmDirectorDto : BaseDto
{
    public int DirectorId { get; set; }
}