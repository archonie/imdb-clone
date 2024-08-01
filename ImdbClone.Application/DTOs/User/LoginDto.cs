using System.ComponentModel.DataAnnotations;

namespace ImdbClone.Application.DTOs.User;

public class LoginDto
{
    [Required, EmailAddress] public string? Username { get; set; } = string.Empty;
    [Required] public string? Password { get; set; } = string.Empty;
}