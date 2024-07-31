using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Domain;
using Microsoft.EntityFrameworkCore;

namespace ImdbClone.Persistence.Repositories;

public class UserRepository: GenericRepository<User>, IUserRepository
{
    private readonly FilmDbContext _dbContext;

    public UserRepository(FilmDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddWatchedFilm(User user, Film film)
    {
        var userToModify = await _dbContext.Users.FindAsync(user.Id);
        var watchedFilm = await _dbContext.Films.FindAsync(film.Id);
        userToModify.WatchedFilms.Add(watchedFilm);
        _dbContext.Entry(userToModify).State = EntityState.Modified;
        _dbContext.SaveChangesAsync();
    }
}