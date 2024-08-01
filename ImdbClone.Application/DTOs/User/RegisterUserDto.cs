using System.ComponentModel.DataAnnotations;

namespace ImdbClone.Application.DTOs.User;

public class RegisterUserDto
{
    
    [Required, EmailAddress] public string? Username { get; set; } = string.Empty;
    [Required] public string? Password { get; set; } = string.Empty;
    [Required, Compare(nameof(Password))] public string? ConfirmPassword { get; set; } = string.Empty;

}