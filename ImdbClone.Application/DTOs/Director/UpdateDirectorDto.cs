using ImdbClone.Application.DTOs.Common;
using ImdbClone.Application.DTOs.Film;

namespace ImdbClone.Application.DTOs.Director;

public class UpdateDirectorDto : BaseDto
{
    public string Name { get; set; }
    public int Age { get; set; }
}