using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Actor;
using ImdbClone.Domain;
using Microsoft.EntityFrameworkCore;

namespace ImdbClone.Persistence.Repositories;

public class ActorRepository : GenericRepository<Actor>, IActorRepository
{
    private readonly FilmDbContext _dbContext;

    public ActorRepository(FilmDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    // public async Task AddCharacter(int id, int characterId )
    // {
    //     var newCharacter = await _dbContext.Characters.FindAsync(characterId);
    //     var actor = await _dbContext.Actors.FindAsync(id);
    //     actor.Characters.Add(newCharacter);
    //     _dbContext.Entry(actor).State = EntityState.Modified;
    //     _dbContext.SaveChangesAsync();
    // }

    public async Task<Actor> GetActorWithCharacters(int id)
    {
        var actor = await _dbContext.Actors
            .Include(a => a.Characters)
            .FirstOrDefaultAsync(a=> a.Id == id);

        return actor;
    }
}