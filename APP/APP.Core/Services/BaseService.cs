using System.Collections.Generic;
using DB;
using DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace APP.Core.Services;
public class BaseService<TEntity>
    where TEntity : BaseEntity
{
    protected static AppDbContext _dbContext;

    protected BaseService(AppDbContext appDbContext)
    {
        _dbContext = appDbContext;
    }
    
    protected static async Task<List<TEntity>> SelectAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }
}