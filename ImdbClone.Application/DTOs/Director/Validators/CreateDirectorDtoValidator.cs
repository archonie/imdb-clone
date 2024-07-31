using FluentValidation;

namespace ImdbClone.Application.DTOs.Director.Validators;

public class CreateDirectorDtoValidator : AbstractValidator<CreateDirectorDto>
{
    public CreateDirectorDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50);
        RuleFor(p => p.Age)
            .GreaterThan(0)
            .NotNull()
            .NotEmpty();
    }
}