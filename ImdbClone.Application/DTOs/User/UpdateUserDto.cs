using ImdbClone.Application.DTOs.Common;
using ImdbClone.Application.DTOs.Film;

namespace ImdbClone.Application.DTOs.User;

public class UpdateUserDto : BaseDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}