using FluentValidation;

namespace ImdbClone.Application.DTOs.Director.Validators;

public class DirectorDtoValidator : AbstractValidator<DirectorDto>
{
    public DirectorDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50);
        RuleFor(p => p.Age)
            .GreaterThan(0)
            .NotEmpty()
            .NotNull();
        
    }
}