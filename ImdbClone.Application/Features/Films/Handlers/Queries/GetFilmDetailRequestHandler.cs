using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Film;
using ImdbClone.Application.Features.Films.Requests.Queries;
using MediatR;

namespace ImdbClone.Application.Features.Films.Handlers.Queries;

public class GetFilmDetailRequestHandler : IRequestHandler<GetFilmDetailRequest, FilmDto>
{
    private readonly IFilmRepository _filmRepository;
    private readonly IMapper _mapper;

    public GetFilmDetailRequestHandler(IFilmRepository filmRepository, IMapper mapper)
    {
        _filmRepository = filmRepository;
        _mapper = mapper;
    }
    public async Task<FilmDto> Handle(GetFilmDetailRequest request, CancellationToken cancellationToken)
    {
        var film = await _filmRepository.GetFilmWithDetails(request.Id);
        return _mapper.Map<FilmDto>(film);
    }
}