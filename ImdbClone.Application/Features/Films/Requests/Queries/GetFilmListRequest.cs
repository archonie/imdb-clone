using ImdbClone.Application.DTOs.Film;
using MediatR;

namespace ImdbClone.Application.Features.Films.Requests.Queries;

public class GetFilmListRequest : IRequest<List<FilmListDto>>
{
    
}