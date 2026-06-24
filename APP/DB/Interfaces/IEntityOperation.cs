namespace DB.Interfaces;

public interface IEntityOperation
{
    Task<bool> SaveAsync(AppDbContext dbContext);
}