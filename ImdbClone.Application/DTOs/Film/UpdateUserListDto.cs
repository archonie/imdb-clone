using ImdbClone.Application.DTOs.Common;
using ImdbClone.Application.DTOs.User;

namespace ImdbClone.Application.DTOs.Film;

public class UpdateUserListDto : BaseDto
{
    public int UserId { get; set; }
}