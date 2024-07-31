using ImdbClone.Domain.Common;

namespace ImdbClone.Domain;

public class Director : BaseDomainEntity
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<Film> Films { get; set; }
}