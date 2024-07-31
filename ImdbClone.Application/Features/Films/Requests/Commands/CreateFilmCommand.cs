using ImdbClone.Application.DTOs.Film;
using ImdbClone.Application.Responses;
using MediatR;

namespace ImdbClone.Application.Features.Films.Requests.Commands;

public class CreateFilmCommand : IRequest<BaseCommandResponse>
{
    public CreateFilmDto FilmDto { get; set; }
}