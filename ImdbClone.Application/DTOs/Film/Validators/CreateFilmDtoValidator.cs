using FluentValidation;
using ImdbClone.Application.Contracts.Persistence;

namespace ImdbClone.Application.DTOs.Film.Validators;

public class CreateFilmDtoValidator : AbstractValidator<CreateFilmDto>
{
    private readonly IDirectorRepository _directorRepository;

    public CreateFilmDtoValidator(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50);
        RuleFor(p => p.DirectorId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var directorExists = await _directorRepository.Exists(id);
                return !directorExists;
            });
        RuleFor(p => p.Description)
            .NotEmpty()
            .NotNull()
            .MaximumLength(255);
    }
}