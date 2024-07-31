using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.Exceptions;
using ImdbClone.Application.Features.Films.Requests.Commands;
using ImdbClone.Domain;
using MediatR;

namespace ImdbClone.Application.Features.Films.Handlers.Commands;

public class DeleteFilmCommandHandler : IRequestHandler<DeleteFilmCommand, Unit>
{
    private readonly IFilmRepository _filmRepository;
    private readonly IMapper _mapper;

    public DeleteFilmCommandHandler(IFilmRepository filmRepository, IMapper mapper)
    {
        _filmRepository = filmRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(DeleteFilmCommand request, CancellationToken cancellationToken)
    {
        var film = await _filmRepository.Get(request.Id);
        if (film == null)
            throw new NotFoundException(nameof(Film), request.Id);
        await _filmRepository.Delete(film);
        return Unit.Value;
    }
}