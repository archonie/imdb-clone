using ImdbClone.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ImdbClone.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly FilmDbContext _dbContext;

    public GenericRepository(FilmDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<T> Get(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id); 
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> Add(T entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task<bool> Exists(int id)
    {
        var entity = await Get(id);
        return entity != null;
    }
}