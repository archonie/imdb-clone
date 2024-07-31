using AutoMapper;
using ImdbClone.Application.DTOs;
using ImdbClone.Application.DTOs.Actor;
using ImdbClone.Application.DTOs.Character;
using ImdbClone.Application.DTOs.Director;
using ImdbClone.Application.DTOs.Film;
using ImdbClone.Application.DTOs.User;
using ImdbClone.Domain;

namespace ImdbClone.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Actor, ActorDto>().ReverseMap();
        CreateMap<Actor, CreateActorDto>().ReverseMap();
        CreateMap<Actor, AddCharacterDto>().ReverseMap();
        CreateMap<Actor, ActorListDto>().ReverseMap();
        CreateMap<Film, FilmDto>().ReverseMap();
        CreateMap<Film, FilmListDto>().ReverseMap();
        CreateMap<Film, CreateFilmDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Character, CharacterDto>().ReverseMap();
        CreateMap<Character, CreateCharacterDto>().ReverseMap();
        CreateMap<Director, DirectorDto>().ReverseMap();
        CreateMap<Director, DirectorListDto>().ReverseMap();
        CreateMap<Director, CreateDirectorDto>().ReverseMap();
    }
}