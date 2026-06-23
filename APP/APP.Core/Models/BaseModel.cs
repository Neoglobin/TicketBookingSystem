using DB;
using DB.Entities;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APP.Core.Models;

public abstract class BaseModel
{
    public TEntity GetEntityInstance<TEntity>()
        where TEntity : BaseEntity, new()
    {
        try
        {
            return new TEntity();
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while trying to create a new instance of an object {typeof(TEntity)}: {ex.Message}");
        }
    }

    protected async Task<bool> SaveEntityAsync<TEntity>(TEntity entity, AppDbContext dbContext)
        where TEntity : BaseEntity
    {
        entity.SetEntityDefValues();
        return await entity.SaveAsync(dbContext);
    }
}