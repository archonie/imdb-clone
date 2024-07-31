using ImdbClone.Application.DTOs.Film;
using MediatR;

namespace ImdbClone.Application.Features.Films.Requests.Commands;

public class UpdateFilmCommand : IRequest<Unit>
{
    public UpdateFilmDto FilmDto { get; set; }
    public UpdateFilmDirectorDto FilmDirectorDto { get; set; }
    public UpdateUserListDto UserListDto { get; set; }
    public UpdateFilmCharactersListDto UpdateFilmCharactersListDto { get; set; }
}