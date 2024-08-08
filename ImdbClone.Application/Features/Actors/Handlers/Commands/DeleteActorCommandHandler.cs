using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.Exceptions;
using ImdbClone.Application.Features.Actors.Requests.Commands;
using ImdbClone.Domain;
using MediatR;

namespace ImdbClone.Application.Features.Actors.Handlers.Commands;

public class DeleteActorCommandHandler: IRequestHandler<DeleteActorCommand, Unit>
{
    private readonly IActorRepository _actorRepository;

    public DeleteActorCommandHandler(IActorRepository actorRepository)
    {
        _actorRepository = actorRepository;
    }
    public async Task<Unit> Handle(DeleteActorCommand request, CancellationToken cancellationToken)
    {
        
        var actor = await _actorRepository.Get(request.Id);
        if (actor == null)
            throw new NotFoundException(nameof(Actor), request.Id);
        await _actorRepository.Delete(actor); 
        return Unit.Value;
    }
}