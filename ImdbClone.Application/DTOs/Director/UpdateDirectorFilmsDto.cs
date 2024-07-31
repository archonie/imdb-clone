using ImdbClone.Application.DTOs.Common;
using ImdbClone.Application.DTOs.Film;

namespace ImdbClone.Application.DTOs.Director;

public class UpdateDirectorFilmsDto : BaseDto
{
    public int FilmId { get; set; }  
}