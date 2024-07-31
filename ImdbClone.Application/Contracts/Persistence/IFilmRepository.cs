using ImdbClone.Domain;

namespace ImdbClone.Application.Contracts.Persistence;

public interface IFilmRepository : IGenericRepository<Film>
{
    Task ChangeDirector(Film film, Director director);
    Task AddUser(Film film, User user);
    //Task AddCharacter(Film film, Character character);

    Task<Film> GetFilmWithDetails(int id);
}