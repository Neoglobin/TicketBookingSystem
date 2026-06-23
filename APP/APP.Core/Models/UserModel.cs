using APP.Core.Helpers;
using APP.Core.Validators;
using DB;
using DB.Entities;
using FluentValidation;

namespace APP.Core.Models;

public class UserModel : BaseModel
{
    public string Email { get; set; }
    
    public string Name { get; set; }
    
    public string Password { get; set; } 
    
    private UserModel(string email, string name, string password)
    {
        Email = email;
        Name = name;
        Password = password;
    }
    
    public static UserModel Create(string email, string name, string password)
    {
        var userModel = new UserModel(email, name, password);

        if (userModel.IsUserValidationPassed(out var validationError))
        {
            throw new ValidationException(validationError);
        }

        return userModel;
    }
    
    public async Task<bool> SaveAsync(User entity, AppDbContext dbContext)
    {
        entity.Email = this.Email;
        entity.Name = this.Name;
        entity.PasswordHash = AuthHelper.HashUserPassword(this.Password);
        
        return await SaveEntityAsync(entity, dbContext);
    }

    
    private bool IsUserValidationPassed(out string validationError)
    {
        bool isValidationPassed = true;
        string error = "";
        validationError = "";
        
        var userValidator = new UserValidator();
        var response = userValidator.Validate(this);
        if (!response.IsValid)
        {
            response.Errors.ForEach(x => error += (x.ErrorMessage + " "));
            validationError = error;
            isValidationPassed = false;
        }
        
        return isValidationPassed;
    }
}