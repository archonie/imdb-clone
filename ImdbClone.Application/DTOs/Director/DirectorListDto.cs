using ImdbClone.Application.DTOs.Common;

namespace ImdbClone.Application.DTOs.Director;

public class DirectorListDto : BaseDto
{
    public string Name { get; set; }
    public int Age { get; set; }
}