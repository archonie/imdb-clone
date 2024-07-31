using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.Exceptions;
using ImdbClone.Application.Features.Directors.Requests.Commands;
using ImdbClone.Domain;
using MediatR;

namespace ImdbClone.Application.Features.Directors.Handlers.Commands;

public class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommand, Unit>
{
    private readonly IDirectorRepository _directorRepository;
    private readonly IMapper _mapper;

    public DeleteDirectorCommandHandler(IDirectorRepository directorRepository, IMapper mapper)
    {
        _directorRepository = directorRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
    {
        var director = await _directorRepository.Get(request.Id);
        if (director == null)
            throw new NotFoundException(nameof(Director), request.Id);
        await _directorRepository.Delete(director);
        return Unit.Value;
    }
}