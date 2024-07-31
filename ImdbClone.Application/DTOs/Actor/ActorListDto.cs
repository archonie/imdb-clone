using ImdbClone.Application.DTOs.Common;

namespace ImdbClone.Application.DTOs.Actor;

public class ActorListDto : BaseDto
{
    public string Name { get; set; }
    public int Age { get; set; }
}