using FluentValidation;
using ImdbClone.Application.Contracts.Persistence;

namespace ImdbClone.Application.DTOs.Actor.Validators;

public class AddCharacterDtoValidator : AbstractValidator<AddCharacterDto>
{
    private readonly ICharacterRepository _characterRepository;

    public AddCharacterDtoValidator(ICharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }
    public AddCharacterDtoValidator()
    {
        RuleFor(p => p.CharacterId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var characterExists = await _characterRepository.Exists(id);
                return !characterExists;
            });

    }
}