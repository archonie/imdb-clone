using FluentValidation;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Character;
using ImdbClone.Application.DTOs.Character.Validators;

namespace ImdbClone.Application.DTOs.Film.Validators;

public class UpdateFilmCharactersListDtoValidator : AbstractValidator<UpdateFilmCharactersListDto>
{
    private readonly IFilmRepository _filmRepository;
    private readonly IActorRepository _actorRepository;

    public UpdateFilmCharactersListDtoValidator(IFilmRepository filmRepository, IActorRepository actorRepository)
    {
        _filmRepository = filmRepository;
        _actorRepository = actorRepository;

        RuleFor(p => p.CharacterDto)
            .NotNull()
            .SetValidator(new CharacterDtoValidator(_filmRepository, _actorRepository));
    }
}