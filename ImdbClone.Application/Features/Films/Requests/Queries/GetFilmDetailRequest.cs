using ImdbClone.Application.DTOs.Film;
using MediatR;

namespace ImdbClone.Application.Features.Films.Requests.Queries;

public class GetFilmDetailRequest : IRequest<FilmDto>
{
    public int Id { get; set; }
}