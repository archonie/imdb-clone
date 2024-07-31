using FluentValidation;

namespace ImdbClone.Application.DTOs.Director.Validators;

public class UpdateDirectorDtoValidator : AbstractValidator<UpdateDirectorDto>
{
    public UpdateDirectorDtoValidator()
    {
        RuleFor(p => p.Age)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50);
    }
}