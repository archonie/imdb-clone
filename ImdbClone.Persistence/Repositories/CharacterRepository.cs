using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Domain;

namespace ImdbClone.Persistence.Repositories;

public class CharacterRepository : GenericRepository<Character>, ICharacterRepository
{
    private readonly FilmDbContext _dbContext;

    public CharacterRepository(FilmDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
}