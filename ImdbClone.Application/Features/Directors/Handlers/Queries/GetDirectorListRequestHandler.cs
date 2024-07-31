using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Director;
using ImdbClone.Application.Features.Directors.Requests.Queries;
using MediatR;

namespace ImdbClone.Application.Features.Directors.Handlers.Queries;

public class GetDirectorListRequestHandler : IRequestHandler<GetDirectorListRequest,List<DirectorListDto>>
{
    private readonly IDirectorRepository _directorRepository;
    private readonly IMapper _mapper;

    public GetDirectorListRequestHandler(IDirectorRepository directorRepository, IMapper mapper)
    {
        _directorRepository = directorRepository;
        _mapper = mapper;
    }

    public async Task<List<DirectorListDto>> Handle(GetDirectorListRequest request, CancellationToken cancellationToken)
    {
        var directors = await _directorRepository.GetAll();
        return _mapper.Map<List<DirectorListDto>>(directors);
    }
}