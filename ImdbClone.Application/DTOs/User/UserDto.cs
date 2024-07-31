using ImdbClone.Application.DTOs.Common;
using ImdbClone.Application.DTOs.Film;

namespace ImdbClone.Application.DTOs.User;

public class UserDto : BaseDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<FilmDto> WatchedFilms { get; set; }
}