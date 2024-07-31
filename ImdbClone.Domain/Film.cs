using ImdbClone.Domain.Common;

namespace ImdbClone.Domain;

public class Film : BaseDomainEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Rate { get; set; }
    public List<User> Users { get; set; }
    public List<Character> Characters { get; set; }
    public Director Director { get; set; }
    public int DirectorId { get; set; }
}