using FluentValidation;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Film.Validators;

namespace ImdbClone.Application.DTOs.Director.Validators;

public class UpdateDirectorFilmsDtoValidator : AbstractValidator<UpdateDirectorFilmsDto>
{
    private readonly IFilmRepository _filmRepository;
    private readonly IDirectorRepository _directorRepository;

    public UpdateDirectorFilmsDtoValidator(IFilmRepository filmRepository, IDirectorRepository directorRepository)
    {
        _filmRepository = filmRepository;
        _directorRepository = directorRepository;
        RuleFor(p => p.FilmId)
            .GreaterThan(0)
            .NotNull()
            .MustAsync(async (id, token) =>
            {
                var filmExists = await _filmRepository.Exists(id);
                return !filmExists;
            });

    }
}