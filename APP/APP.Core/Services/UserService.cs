using APP.Core.Models;
using DB;
using DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace APP.Core.Services;

public class UserService : BaseService<User>
{
    public UserService(AppDbContext appDbContext) : base(appDbContext)
        {}

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await SelectAllAsync();
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _dbContext.User.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == email) ?? throw new Exception();
    }
}