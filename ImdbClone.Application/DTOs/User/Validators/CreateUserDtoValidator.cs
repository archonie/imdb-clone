using FluentValidation;

namespace ImdbClone.Application.DTOs.User.Validators;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
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