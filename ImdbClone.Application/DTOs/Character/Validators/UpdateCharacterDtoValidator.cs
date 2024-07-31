using FluentValidation;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Actor;

namespace ImdbClone.Application.DTOs.Character.Validators;

public class UpdateCharacterDtoValidator : AbstractValidator<UpdateCharacterDto>
{
    private readonly IFilmRepository _filmRepository;
    private readonly IActorRepository _actorRepository;

    public UpdateCharacterDtoValidator(IFilmRepository filmRepository, IActorRepository actorRepository)
    {
        _filmRepository = filmRepository;
        _actorRepository = actorRepository;
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50);

        RuleFor(p => p.Description)
            .MaximumLength(255);
        
        RuleFor(p => p.FilmId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var filmExists = await _filmRepository.Exists(id);
                return !filmExists;
            });
        RuleFor(p => p.ActorId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var actorExists = await _actorRepository.Exists(id);
                return !actorExists;
            });
    }
}