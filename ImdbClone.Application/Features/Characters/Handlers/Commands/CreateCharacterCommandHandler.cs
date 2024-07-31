using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Character.Validators;
using ImdbClone.Application.Exceptions;
using ImdbClone.Application.Features.Characters.Requests.Commands;
using ImdbClone.Application.Responses;
using ImdbClone.Domain;
using MediatR;

namespace ImdbClone.Application.Features.Characters.Handlers.Commands;

public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, BaseCommandResponse>
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IActorRepository _actorRepository;
    private readonly IFilmRepository _filmRepository;
    private readonly IMapper _mapper;

    public CreateCharacterCommandHandler(
        ICharacterRepository characterRepository, 
        IActorRepository actorRepository, 
        IFilmRepository filmRepository,
        IMapper mapper
        )
    {
        _characterRepository = characterRepository;
        _actorRepository = actorRepository;
        _filmRepository = filmRepository;
        _mapper = mapper;
    }
    public async Task<BaseCommandResponse> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateCharacterDtoValidator(_filmRepository, _actorRepository);
        var validationResult = await validator.ValidateAsync(request.CharacterDto);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        var character = _mapper.Map<Character>(request.CharacterDto);
        character = await _characterRepository.Add(character);
        response.Success = true;
        response.Message = "Creation Successful";
        response.Id = character.Id;
        return response;
    }
}