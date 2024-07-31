using ImdbClone.Domain.Common;

namespace ImdbClone.Domain;

public class Character : BaseDomainEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Film Film { get; set; } 
    public int FilmId { get; set; }
    public Actor Actor{ get; set; }
    public int ActorId { get; set; }
    
}