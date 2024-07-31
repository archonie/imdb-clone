using ImdbClone.Domain;

namespace ImdbClone.Application.Contracts.Persistence;

public interface IDirectorRepository : IGenericRepository<Director>
{
    //Task AddFilm(int id, int filmId);
    Task<Director> GetDirectorWithFilms(int id);
}