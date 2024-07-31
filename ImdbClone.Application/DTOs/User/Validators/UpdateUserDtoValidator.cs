using FluentValidation;

namespace ImdbClone.Application.DTOs.User.Validators;

public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserDtoValidator()
    {
        RuleFor(p => p.Username)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50);
        RuleFor(p => p.Password)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50);
    }
}