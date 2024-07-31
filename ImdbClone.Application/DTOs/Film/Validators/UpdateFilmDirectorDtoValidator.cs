using FluentValidation;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Director;
using ImdbClone.Application.DTOs.Director.Validators;

namespace ImdbClone.Application.DTOs.Film.Validators;

public class UpdateFilmDirectorDtoValidator : AbstractValidator<UpdateFilmDirectorDto>
{
    private readonly IDirectorRepository _directorRepository;

    public UpdateFilmDirectorDtoValidator(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;

        RuleFor(p => p.DirectorId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var directorExists = await _directorRepository.Exists(id);
                return !directorExists;
            });
    }
}