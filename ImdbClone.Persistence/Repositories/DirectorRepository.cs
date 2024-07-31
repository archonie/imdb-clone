using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Domain;
using Microsoft.EntityFrameworkCore;

namespace ImdbClone.Persistence.Repositories;

public class DirectorRepository : GenericRepository<Director>, IDirectorRepository
{
    private readonly FilmDbContext _dbContext;

    public DirectorRepository(FilmDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    
    // public async Task AddFilm(int id, int filmId)
    // {
    //     var directorToModify = await _dbContext.Directors.FindAsync(id);
    //     var newFilm = await _dbContext.Films.FindAsync(filmId);
    //     directorToModify.Films.Add(newFilm);
    //     _dbContext.Entry(directorToModify).State = EntityState.Modified;
    //     _dbContext.SaveChangesAsync();
    // }

    public async Task<Director> GetDirectorWithFilms(int id)
    {
        var director = await _dbContext.Directors
            .Include(a => a.Films)
            .FirstOrDefaultAsync(d=> d.Id == id);
        
        return director;
    }
}