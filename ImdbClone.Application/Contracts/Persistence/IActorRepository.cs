using ImdbClone.Application.DTOs.Actor;
using ImdbClone.Application.DTOs.Character;
using ImdbClone.Domain;

namespace ImdbClone.Application.Contracts.Persistence;

public interface IActorRepository : IGenericRepository<Actor>
{
    //Task AddCharacter(int id, int characterId);
    Task<Actor> GetActorWithCharacters(int id);
}