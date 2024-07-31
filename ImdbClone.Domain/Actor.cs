using ImdbClone.Domain.Common;

namespace ImdbClone.Domain;

public class Actor : BaseDomainEntity
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<Character> Characters { get; set; }
}