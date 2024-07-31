using ImdbClone.Application.DTOs.Common;

namespace ImdbClone.Application.DTOs.User;

public class CreateUserDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}