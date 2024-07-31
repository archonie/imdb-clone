using FluentValidation;
using ImdbClone.Application.Contracts.Persistence;

namespace ImdbClone.Application.DTOs.Film.Validators;

public class UpdateFilmDtoValidator : AbstractValidator<UpdateFilmDto>
{
    private readonly IDirectorRepository _directorRepository;

    public UpdateFilmDtoValidator(IDirectorRepository directorRepository)
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

    }
}