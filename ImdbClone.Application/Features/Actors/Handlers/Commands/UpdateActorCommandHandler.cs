using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Actor.Validators;
using ImdbClone.Application.Exceptions;
using ImdbClone.Application.Features.Actors.Requests.Commands;
using ImdbClone.Domain;
using MediatR;

namespace ImdbClone.Application.Features.Actors.Handlers.Commands;

public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand, Unit>
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IActorRepository _actorRepository;
    private readonly IMapper _mapper;

    public UpdateActorCommandHandler(ICharacterRepository characterRepository, IActorRepository actorRepository, IMapper mapper)
    {
        _characterRepository = characterRepository;
        _actorRepository = actorRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
    {   
        if (request.ActorDto != null)
        {
            // var validator = new UpdateActorDtoValidator();
            // var validationResult = await validator.ValidateAsync(request.ActorDto);
            // if (!validationResult.IsValid)
            // {
            //     throw new ValidationException(validationResult);
            // }
            var actor = await _actorRepository.Get(request.ActorDto.Id);
            _mapper.Map(request.ActorDto, actor);
            await _actorRepository.Update(actor);
        }
        // else if (request.AddCharacterDto != null)
        // {
        //     // var validator = new AddCharacterDtoValidator();
        //     // var validationResult = await validator.ValidateAsync(request.AddCharacterDto);
        //     // if (!validationResult.IsValid)
        //     // {
        //     //     throw new ValidationException(validationResult);
        //     // }
        //
        //     var actor = await _actorRepository.Get(request.AddCharacterDto.Id);
        //     var character = _mapper.Map<Character>(await _characterRepository.Get(request.AddCharacterDto.CharacterId));
        //     await _actorRepository.AddCharacter(actor.Id, character.Id);
        // }

        return Unit.Value;
    }
}