using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Domain;
using Microsoft.EntityFrameworkCore;

namespace ImdbClone.Persistence.Repositories;

public class FilmRepository : GenericRepository<Film>, IFilmRepository
{
    private readonly FilmDbContext _dbContext;

    public FilmRepository(FilmDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ChangeDirector(Film film, Director director)
    {
        var directedFilm = await _dbContext.Films.FindAsync(film.Id);
        var newDirector = await _dbContext.Directors.FindAsync(director.Id);
        film.Director = newDirector;
        _dbContext.Entry(film).State = EntityState.Modified;
        _dbContext.SaveChangesAsync();

    }

    public async Task AddUser(Film film, ApplicationUser user)
    {
        var watchedFilm = await _dbContext.Films.FindAsync(film.Id);
        var userWatched = await _dbContext.Users.FindAsync(user.Id);
        film.Users.Add(userWatched);
        _dbContext.Entry(film).State = EntityState.Modified;
        _dbContext.SaveChangesAsync();
    }

    public async Task<Film> GetFilmWithDetails(int id)
    {
        var film = await _dbContext.Films
            .Include(f => f.Characters)
            .Include(f => f.Director)
            .Include(f => f.Users)
            .FirstOrDefaultAsync(f => f.Id == id);
        return film;
    }

    // public async Task AddCharacter(Film film, Character character)
    // {
    //     var filmCharacter = await _dbContext.Films.FindAsync(film.Id);
    //     var newCharacter = await _dbContext.Characters.FindAsync(character.Id);
    //     film.Characters.Add(newCharacter);
    //     _dbContext.Entry(film).State = EntityState.Modified;
    //     _dbContext.SaveChangesAsync();
    // }
}