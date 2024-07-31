using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.Exceptions;
using ImdbClone.Application.Features.Characters.Requests.Commands;
using ImdbClone.Domain;
using MediatR;

namespace ImdbClone.Application.Features.Characters.Handlers.Commands;

public class DeleteCharacterCommandHandler : IRequestHandler<DeleteCharacterCommand, Unit>
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IMapper _mapper;

    public DeleteCharacterCommandHandler(ICharacterRepository characterRepository, IMapper mapper)
    {
        _characterRepository = characterRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(DeleteCharacterCommand request, CancellationToken cancellationToken)
    {
        var character = await _characterRepository.Get(request.Id);
        if (character == null)
            throw new NotFoundException(nameof(Character), request.Id);
        await _characterRepository.Delete(character);
        return Unit.Value;
        
    }
}