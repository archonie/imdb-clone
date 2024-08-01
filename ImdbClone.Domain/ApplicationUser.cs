using ImdbClone.Domain.Common;

namespace ImdbClone.Domain;

public class ApplicationUser : BaseDomainEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Film> WatchedFilms { get; set; }
}