using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Director;
using ImdbClone.Application.Features.Directors.Requests.Queries;
using MediatR;

namespace ImdbClone.Application.Features.Directors.Handlers.Queries;

public class GetDirectorDetailRequestHandler : IRequestHandler<GetDirectorDetailRequest,DirectorDto>
{
    private readonly IDirectorRepository _directorRepository;
    private readonly IMapper _mapper;

    public GetDirectorDetailRequestHandler(IDirectorRepository directorRepository, IMapper mapper)
    {
        _directorRepository = directorRepository;
        _mapper = mapper;
    }
    public async Task<DirectorDto> Handle(GetDirectorDetailRequest request, CancellationToken cancellationToken)
    {
        var director = await _directorRepository.GetDirectorWithFilms(request.Id);
        return _mapper.Map<DirectorDto>(director);
    }
}