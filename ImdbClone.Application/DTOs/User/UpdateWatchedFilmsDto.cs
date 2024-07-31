using ImdbClone.Application.DTOs.Common;
using ImdbClone.Application.DTOs.Film;

namespace ImdbClone.Application.DTOs.User;

public class UpdateWatchedFilmsDto : BaseDto
{
    public FilmDto WatchedFilm { get; set; }

}