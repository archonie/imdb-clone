using ImdbClone.Domain;

namespace ImdbClone.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    Task AddWatchedFilm(User user, Film film);
}