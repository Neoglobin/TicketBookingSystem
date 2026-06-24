using APP.Core.Helpers;
using APP.Core.Models;
using DB;
using DB.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace APP.Core.Services;

public class UserService(AppDbContext dbContext)
{
    public async Task<bool> Register(string email, string name, string password)
    {
        var userModel = UserModel.Create(email, name, password);
        var entity = new User();
        
        entity.Email = email;
        entity.Name = name;
        entity.PasswordHash = AuthHelper.HashUserPassword(password);

        return await entity.SaveAsync(dbContext);
    }

    public async Task<User> GetVerifiedUser(string email, string password)
    {
        var user = await dbContext.User.Where(x => x.Email == email).FirstOrDefaultAsync()
            ?? throw new Exception();
        
        if (!AuthHelper.Verify(password, user.PasswordHash))
        {
            throw new Exception("Incorrect user password");
        }

        return user;
    }
    

}