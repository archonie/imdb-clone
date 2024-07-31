using AutoMapper;
using FluentValidation;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Character;
using ImdbClone.Application.DTOs.Character.Validators;
using ImdbClone.Application.Features.Characters.Requests.Commands;
using MediatR;
using ValidationException = ImdbClone.Application.Exceptions.ValidationException;

namespace ImdbClone.Application.Features.Characters.Handlers.Commands;

public class UpdateCharacterCommandHandler : IRequestHandler<UpdateCharacterCommand, Unit>
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IFilmRepository _filmRepository;
    private readonly IActorRepository _actorRepository;
    private readonly IMapper _mapper;

    public UpdateCharacterCommandHandler(ICharacterRepository characterRepository, IFilmRepository filmRepository,
        IActorRepository actorRepository, IMapper mapper)
    {
        _characterRepository = characterRepository;
        _filmRepository = filmRepository;
        _actorRepository = actorRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateCharacterCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCharacterDtoValidator(_filmRepository, _actorRepository);
        var validationResult = await validator.ValidateAsync(request.CharacterDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }
        var character = await _characterRepository.Get(request.CharacterDto.Id);
        _mapper.Map(request.CharacterDto, character);
        await _characterRepository.Update(character);
        return Unit.Value;
    }
}