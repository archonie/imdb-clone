using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Film;
using ImdbClone.Application.Features.Films.Requests.Queries;
using MediatR;

namespace ImdbClone.Application.Features.Films.Handlers.Queries;

public class GetFilmListRequestHandler : IRequestHandler<GetFilmListRequest, List<FilmListDto>>
{
    private readonly IFilmRepository _filmRepository;
    private readonly IMapper _mapper;

    public GetFilmListRequestHandler(IFilmRepository filmRepository, IMapper mapper)
    {
        _filmRepository = filmRepository;
        _mapper = mapper;
    }
    public async Task<List<FilmListDto>> Handle(GetFilmListRequest request, CancellationToken cancellationToken)
    {
        var films = await _filmRepository.GetAll();
        return _mapper.Map<List<FilmListDto>>(films);
    }
}