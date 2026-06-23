using APP.Core.Models;
using APP.Core.Validators.UserValidators;
using FluentValidation;

namespace APP.Core.Validators;

public class UserValidator : AbstractValidator<UserModel>
{
    public UserValidator()
    {
        Include(new UserPasswordValidator());
    }
}