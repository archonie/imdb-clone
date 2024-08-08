using FluentValidation;

namespace ImdbClone.Application.DTOs.Actor.Validators;

public class UpdateActorDtoValidator : AbstractValidator<UpdateActorDto>
{
    public UpdateActorDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} must be provided.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue}");
        RuleFor(p => p.Age)
            .NotEmpty().WithMessage("{PropertyName} must be provided.")
            .NotNull()
            .GreaterThan(0).WithMessage("{PropertyName} cannot be less than or equal to {ComparisonValue}");
            
        // RuleFor(p => p.Characters)
        //     .NotNull()
        //     .NotEmpty().WithMessage("{PropertyName} must be provided.");

    }
}