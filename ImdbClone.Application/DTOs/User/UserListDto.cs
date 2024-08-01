using ImdbClone.Application.DTOs.Common;
using ImdbClone.Application.DTOs.Film;

namespace ImdbClone.Application.DTOs.User;

public class UserListDto : BaseDto
{
    public string Username { get; set; }
}