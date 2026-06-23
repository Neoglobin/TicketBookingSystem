using APP.Core.Models;
using DB.Entities;
using FluentValidation;

namespace APP.Core.Validators.UserValidators;

public class UserPasswordValidator : AbstractValidator<UserModel>
{
    public UserPasswordValidator()
    {
        RuleFor(user => user.Password).NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password cannot contain less than 8 characters")
            .MaximumLength(24).WithMessage("Password cannot be longer than 16 characters")
            .Matches(@"[A-Z]+").WithMessage("Password must contain at least one upper-case character")
            .Matches(@"[a-z]+").WithMessage("Password must contain at least one lower-case character")
            .Matches(@"[0-9]+").WithMessage("Password must contain at least one number")
            .Matches(@"[\!\?\*\.]+").WithMessage("Password must contain at least one special symbol");
    }
}