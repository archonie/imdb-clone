using ImdbClone.Domain;

namespace ImdbClone.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<ApplicationUser>
{
    Task AddWatchedFilm(ApplicationUser user, Film film);
    Task<ApplicationUser> FindUserByEmail(string email);
    string GenerateToken(ApplicationUser user);

}