using ImdbClone.Application.DTOs.Common;

namespace ImdbClone.Application.DTOs.Actor;

public class CreateActorDto 
{
    public string Name { get; set; }
    public int Age { get; set; }
}