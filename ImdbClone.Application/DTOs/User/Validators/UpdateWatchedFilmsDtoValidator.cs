using FluentValidation;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Film.Validators;

namespace ImdbClone.Application.DTOs.User.Validators;

public class UpdateWatchedFilmsDtoValidator : AbstractValidator<UpdateWatchedFilmsDto>
{
    private readonly IDirectorRepository _directorRepository;

    public UpdateWatchedFilmsDtoValidator(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;
        RuleFor(p => p.WatchedFilm)
            .NotNull()
            .SetValidator(new FilmDtoValidator(_directorRepository));
    }
}